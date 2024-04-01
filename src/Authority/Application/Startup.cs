using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace PastExamsHub.Authority.Application
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
            Base.Application.Startup.ConfigureServices(services, configuration, environment);
        }
    }
}
