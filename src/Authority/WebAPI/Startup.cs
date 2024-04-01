using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PastExamsHub.Authority.Infrastructure.Persistence;

namespace PastExamsHub.Authority.WebAPI
{
    public class Startup : Base.WebAPI.Startup
    {
        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment environment
        ) : base(configuration, environment)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            Application.Startup.ConfigureServices(services, Configuration, Environment);
            Infrastructure.Startup.ConfigureServices(services, Configuration, Environment);

            base.ConfigureServices(services);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //On MVC project if user is not authorize application try to call /login method by default
            //This code enable MVC to work line web api and return status 401 insteed to call /login method
            services.ConfigureApplicationCookie(options =>
            {
                options.Events = new CookieAuthenticationEvents
                {
                    OnValidatePrincipal = SecurityStampValidator.ValidatePrincipalAsync,
                    OnRedirectToLogin = async (context) => context.Response.StatusCode = 401,
                    OnRedirectToAccessDenied = async (context) => context.Response.StatusCode = 403
                };
            });

            //if authority runs on http ,this enable cookie to be send across CORS domains
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.SameSite = SameSiteMode.None;
            });

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromDays(7);
            });
        }

        protected override void ConfigureServicesForHealthChecks(IHealthChecksBuilder healthChecksBuilder)
        {
            base.ConfigureServicesForHealthChecks(healthChecksBuilder);

            healthChecksBuilder.AddDbContextCheck<AuthorityDbContext>();
        }

        protected override void ConfigureServicesForSecurity(IServiceCollection services)
        {
            //IMPORTANT: Authority does not need Authentication
            //base.ConfigureServicesForSecurity(services);
            base.ConfigureServicesForSecurity(services);
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use((context, next) =>
            {
                context.Items["__CorsMiddlewareInvoked"] = true;
                return next();
            });

            base.Configure(app, env);
        }

        protected override void ConfigureSecurity(IApplicationBuilder app)
        {
            //IMPORTANT: Authority does not need Authentication
            //base.ConfigureSecurity(app);

            // IMPORTANT: must come between UseRouting & UseEndpoints
            // more @ https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing

            app.Use(async (context, next) =>
            {
                await next();

                if (string.Compare(context.Request.Path, "/connect/authorize/callback", StringComparison.InvariantCulture) == 0)
                {
                    await context.SignOutAsync(IdentityConstants.ApplicationScheme);//using Microsoft.AspNetCore.Authentication
                    Serilog.Log.Logger.Information("Signed out after authorize callback");
                }
            });

            app.UseIdentityServer();
            //If you need BaseUrlMiddleware please uncomment three line below and comment line above
            //and change "URL" to real URL that you want to use for IdentityServerURL (authority URL)
            //app.UseMiddleware<IdentityBaseUrlMiddleware>("URL"); 
            //app.ConfigureCors();
            //app.UseMiddleware<IdentityServerMiddleware>();

            base.ConfigureSecurity(app);//TODO: do we want to call base in Authority? if so, can this come first?
        }
    }
}
