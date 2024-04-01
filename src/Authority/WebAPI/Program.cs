using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Threading.Tasks;

namespace PastExamsHub.Authority.WebAPI
{
    public class Program
    {
        public async static Task<int> Main(string[] args)
        {
            var bootstrapper = new Bootstrapper(args);
            return await bootstrapper.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var bootstrapper = new Bootstrapper(args);
            return bootstrapper.CreateHostBuilder(args);
        }
    }
}
