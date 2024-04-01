using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using PastExamsHub.Authority.Application.Common.Interfaces;
using PastExamsHub.Authority.Infrastructure.Persistence;
using PastExamsHub.Base.Infrastructure;
using PastExamsHub.Base.Infrastructure.Identity;
using PastExamsHub.Authority.Infrastructure.Extensions;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Infrastructure.Services;
using PastExamsHub.Authority.Infrastructure.Services;
using System.Linq;
using IdentityServer4.Hosting;
using IdentityServer4.ResponseHandling;
using PastExamsHub.Authority.Infrastructure.Identity;
using PastExamsHub.Base.Domain.Common;
using System.Security.Cryptography.X509Certificates;

namespace PastExamsHub.Authority.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices
        (
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment
           // IHttpContextAccessor httpContextAccessor
        )
        {
            var authenticationOptions = configuration.Read<Base.Application.Options.Authentication>();
            var identityServerOptions = configuration.Read<Application.Options.IdentityServer>();

            //System.Diagnostics.Debugger.Break();
            Base.Infrastructure.Startup.ConfigureServices(services, configuration, environment);

            services.AddMemoryCache();//TODO: compare to AddDistributedMemoryCache

            var authorityDbContextOptionsBuilder = new Action<DbContextOptionsBuilder>(options => options.ConfigureDbContext<AuthorityDbContext>(configuration, environment));
            services.AddDbContext<AuthorityDbContext>(authorityDbContextOptionsBuilder)
                .AddScoped<IAuthorityDbContext, AuthorityDbContext>();

            var configurationDbContextOptionsBuilder = new Action<DbContextOptionsBuilder>(options => options.ConfigureDbContext<ConfigurationDbContext>(configuration, environment));
            services.AddDbContext<ConfigurationDbContext>(configurationDbContextOptionsBuilder)
                .AddScoped<IConfigurationDbContext, ConfigurationDbContext>();

            var persistedGrantDbContextOptionsBuilder = new Action<DbContextOptionsBuilder>(options => options.ConfigureDbContext<PersistedGrantDbContext>(configuration, environment));
            services.AddDbContext<PersistedGrantDbContext>(persistedGrantDbContextOptionsBuilder)
                .AddScoped<IPersistedGrantDbContext, PersistedGrantDbContext>();


            services.AddIdentity<IdentityApplicationUser, IdentityRole>(options => 
                {
                    //TODO: set this up only for unit tests (no email confirmation required)
                    //options.SignIn.RequireConfirmedEmail = true;
                    //TODO: strenghten
                    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes("AppSettings:DefaultLockoutTimeSpan");
                    //options.Lockout.MaxFailedAccessAttempts = ToInt("AppSettings:MaxFailedAccessAttempts");
                    options.User.RequireUniqueEmail = true;
                    //TODO: consider
                    //options.Tokens.EmailConfirmationTokenProvider
                })
                .AddEntityFrameworkStores<AuthorityDbContext>()
                .AddDefaultTokenProviders();//using Microsoft.AspNetCore.Identity

            Log.Logger.Information("Configuring identity server started");

            var identityBuilder = services.AddIdentityServer(options =>
            {
                options.UserInteraction.LoginUrl = authenticationOptions.SignInUrl;
                options.UserInteraction.LogoutUrl = authenticationOptions.SignOutUrl;
                //TODO: understand how these work:
                //options.PublicOrigin = settings.PublicOrigin;
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                //https://identityserver4.readthedocs.io/en/latest/quickstarts/5_entityframework.html
                //http://docs.identityserver.io/en/latest/reference/ef.html
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = configurationDbContextOptionsBuilder;
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = persistedGrantDbContextOptionsBuilder;

                })
                .AddDeveloperSigningCredential()
                //.AddSigningCredential(new X509Certificate2("D:\\0.Diplomski rad\\PastExamsHub_API\\src\\Authority\\Infrastructure\\Files\\cert.pfx", ""))//IMPORTANT: custom extension method from Template.Authority.Infrastructure.Extensions
                .AddAspNetIdentity<IdentityApplicationUser>()
                .AddJwtBearerClientAuthentication()
                .AddProfileService<ProfileService>();
            //.AddCustomTokenRequestValidator<CustomTokenRequestValidator>();

            /*
            identityBuilder.Services
                .Where(service => service.ServiceType == typeof(Endpoint))
                .Select(item => (Endpoint)item.ImplementationInstance)
                .ToList()
                .ForEach(item => item.Path = item.Path.Value.Replace("/connect/", "/oauth2/v1/"));
            services.AddTransient<IDiscoveryResponseGenerator, Identity.CustomDiscoveryResponseGenerator>();
            services.AddTransient<IEndpointRouter, Identity.CustomEndpointRouter>();
            */

            services.AddTransient<IEmailTemplateService, EmailTemplateService>();
            services.AddTransient<IApplicationUser, ApplicationUser>();
            services.AddTransient<IIdentityService, IdentityService>();

            Log.Logger.Information("Configuring identity server completed");

            return services;
        }
    }
}
