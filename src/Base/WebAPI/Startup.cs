using FluentValidation.AspNetCore;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.WebAPI.Filters;
using PastExamsHub.Base.WebAPI.Services;
using Newtonsoft.Json.Converters;
using Serilog;
using Serilog.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using IdentityModel.AspNetCore.OAuth2Introspection;
using Microsoft.AspNetCore.HttpOverrides;
using PastExamsHub.Base.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PastExamsHub.Base.Infrastructure.Persistence;
using PastExamsHub.Base.WebAPI.SignalR;

namespace PastExamsHub.Base.WebAPI
{
    public abstract class Startup
    {
        protected readonly IConfiguration Configuration;
        protected readonly IHostEnvironment Environment;

        public Startup
        (
            IConfiguration configuration, 
            IHostEnvironment environment
        )
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            //https://github.com/serilog/serilog-aspnetcore/blob/dev/samples/InlineInitializationSample/Startup.cs
            services.Configure<RequestLoggingOptions>(o =>
            {
                o.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set(nameof(httpContext.Connection.RemoteIpAddress), httpContext.Connection.RemoteIpAddress.MapToIPv4());
                };
            });

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
 			services.AddSingleton<IConnectionStorage, InMemoryConnectionStorage>();

            var connectionString = Configuration.GetConnectionString(nameof(ApplicationDbContext));
			
			/*
			services.AddHangfire(connectionString);
			services.AddTransient<ExampleJob>();
			*/

            var healthChecksBuilder = services.AddHealthChecks();
            ConfigureServicesForHealthChecks(healthChecksBuilder);

            // https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/proxy-load-balancer?view=aspnetcore-5.0
            // https://github.com/IdentityServer/IdentityServer4/issues/1331
            // Need if services run as reverse proxy over NGINIX
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.RequireHeaderSymmetry = false;
                // Only loopback proxies are allowed by default.
                // Clear that restriction because forwarders are enabled by explicit 
                // configuration.
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            services.AddHttpContextAccessor();

            services.AddControllers(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                // https://thecodebuzz.com/add-newtonsoft-json-support-net-core
                // https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.All;//IMPORTANT: use for loop serialization debugging
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());//using Newtonsoft.Json.Converters;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;

                    if (Environment.IsProduction())
                    {
                        options.SerializerSettings.Formatting = Formatting.None;
                    }
                })
                //https://docs.fluentvalidation.net/en/latest/aspnet.html
                .AddFluentValidation();


            //TODO: Needed for email rendering (GBI.EnterpriseServices.Storage.StorageApi.Application.Emails.Services.RazorViewToStringRenderer)
            //services.AddRazorPages();

            services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddApiVersioning();//TODO: consider

            ConfigureServicesForSecurity(services);

            //TODO: check if we still need this
            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddOpenAPI();//TODO: extract all into AuthorityExtensions (OpenApiExtensions)
        }

        protected virtual void ConfigureServicesForHealthChecks(IHealthChecksBuilder healthChecksBuilder)
        {
        }

        protected virtual void ConfigureServicesForSecurity(IServiceCollection services)
        {
            Log.Logger.Information("Configuring authentication started");

            var configurationOptions = this.Configuration.Read<Application.Options.Authentication>();//using Template.Base.Infrastructure

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configurationOptions.AuthorityUrl;//IdentityServer URL
                    options.RequireHttpsMetadata = configurationOptions.RequireHttpsMetadata;//False for local addresses, true ofcourse for live scenarios
                    options.ApiName = configurationOptions.ApiResourceName;
                    options.ApiSecret = configurationOptions.ApiResourceSecret;
                    //TODO: add article url
                    options.TokenRetriever = new Func<HttpRequest, string>(req =>
                    {
                        var fromHeader = TokenRetrieval.FromAuthorizationHeader();
                        var fromQuery = TokenRetrieval.FromQueryString();
                        return fromHeader(req) ?? fromQuery(req);
                    });
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));//TODO: configurable?
                //TODO: consider
                /*
                options.AddPolicy(Startup.ApiPolicyName, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", settings.ApiName);
                    // more @ https://identityserver4.readthedocs.io/en/latest/topics/apis.html#validating-scopes
                });
                */
            });

            //https://identityserver4.readthedocs.io/en/latest/quickstarts/4_javascript_client.html#allowing-ajax-calls-to-the-web-api-with-cors
            //https://identityserver4.readthedocs.io/en/latest/topics/cors.html
            services.AddCors(options =>
            {
                options.AddPolicy(
                    configurationOptions.DefaultCorsPolicyName,
                    policy =>
                    {
                        //TODO: tighten down
                        if (configurationOptions.CorsOrigins == null)
                        {
                            policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        }
                        else
                        {
                            var origins = configurationOptions.CorsOrigins.Split(';', StringSplitOptions.RemoveEmptyEntries);
                            policy.WithOrigins(origins)//TODO: read from Clients in ConfigurationDbContext
                                .AllowCredentials()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        }
                    }
                );
                options.AddPolicy(
                    configurationOptions.AllowAllCorsPolicyName,
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    }
                );
            });

            Log.Logger.Information("Configuring authentication completed");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure
        (
            IApplicationBuilder app, 
            IWebHostEnvironment env
            //HangfireDependencyInjectionActivator hangfireActivator
        )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHealthChecks("/health");
            //app.UseHttpsRedirection();//IMPORTANT: not needed, as reverse proxy in front of this will take care of HTTPS

            app.UseForwardedHeaders(
                /*
                new ForwardedHeadersOptions
                {
                    ForwardedHeaders = (ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto) //using Microsoft.AspNetCore.HttpOverrides;
                }
                */
            );

            //TODO: is this still good?
            //https://github.com/serilog/serilog-aspnetcore#request-logging
            app.UseSerilogRequestLogging();

            app.UseOpenAPI();
            //TODO: strenghten
            /*
            app.Use(async (context, next) =>
            {
                //set standard security headers
                context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");
                context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Append("X-Frame-Options", "ALLOW-FROM template.com");//TODO: what is this for?

                context.Response.Headers.Remove("x-powered-by");

                context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin"); //only send referrers when going to our own site on https
                context.Response.Headers.Add("Feature-Policy", "geolocation 'none'; camera 'none'; microphone 'none' "); //we do not need features
                await next.Invoke();
            });
            */

            app.UseRouting();

            //IMPORTANT: must be called between UseRouting & UseEndpoints
            ConfigureSecurity(app);

            /*
			app.UseHangfire(hangfireActivator);
            Hangfire.RecurringJob.AddOrUpdate<ExampleJob>(
                nameof(ExampleJob),
                job => job.Execute(System.Threading.CancellationToken.None),
                Hangfire.Cron.Daily()
            );
			*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        protected virtual void ConfigureSecurity(IApplicationBuilder app)
        {
            var configurationOptions = this.Configuration.Read<Application.Options.Authentication>();//using Template.Base.Infrastructure

            app.UseCors(configurationOptions.DefaultCorsPolicyName);
            //IMPORTANT: when using UseAuthentication in combination with UseAuthorization, UseAuthentication needs to come first
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
