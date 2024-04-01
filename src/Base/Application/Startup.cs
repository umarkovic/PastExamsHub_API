using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PastExamsHub.Base.Application.Common.Behaviours;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace PastExamsHub.Base.Application
{
    public static class Startup
    {
        public static void ConfigureServices
        (
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment
        )
        {
            {
                var assembly = Assembly.GetExecutingAssembly();
                services.RegisterAssembly(assembly);

                //TODO: consider adding commented
                //LoggingBehavior
                services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
                services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
                services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
                services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
                //TransactionBehaviour
            }
            {
                var assembly = Assembly.GetCallingAssembly();//HACK: assumes the above layers
                services.RegisterAssembly(assembly);
            }
            {
                var assembly = Assembly.GetEntryAssembly();//HACK: assumes the above layers
                services.RegisterAssembly(assembly);
            }
        }

        static void RegisterAssembly(this IServiceCollection services, Assembly assembly)
        {
            //services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(assembly);
        }

        /*
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
        */
    }
}
