using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using PastExamsHub.Base.Application.Common.Behaviours;
using FluentValidation;
using MediatR;


namespace PastExamsHub.Core.Application
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices
        (
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment
        )
        {
            Base.Application.Startup.ConfigureServices(services, configuration, environment);

            var assembly = Assembly.GetCallingAssembly();//HACK: assumes the above layers
            services.RegisterAssembly(assembly);

            return services;
        }

        static void RegisterAssembly(this IServiceCollection services, Assembly assembly)
        {
            services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(assembly);
        }
    }
}
