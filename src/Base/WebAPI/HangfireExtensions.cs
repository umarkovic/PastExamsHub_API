using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Base.WebAPI
{
    public static class HangfireExtensions
    {
        public static void AddHangfire(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<HangfireDependencyInjectionActivator>();
            services.AddHangfire(globalConfiguration => {
                globalConfiguration.UseSqlServerStorage(connectionString)
                    .UseSerializerSettings(new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    });
            });
            services.AddHangfireServer();
        }

        public static void UseHangfire(this IApplicationBuilder app, HangfireDependencyInjectionActivator hangfireActivator)
        {
            //app.UseHangfireDashboard();

            // TODO: turn off filter before production
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new CustomDashboardAuthorizationFilter() }
            });

            Hangfire.GlobalConfiguration.Configuration.UseActivator(hangfireActivator);
        }
    }
}
