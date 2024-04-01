using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization.Internal;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Threading.Tasks;

namespace PastExamsHub.Base.WebAPI
{
    public abstract class BootstrapperBase<TStartup> where TStartup : class
    {
        readonly string[] args;

        public BootstrapperBase(string[] args)
        {
            this.args = args;
        }

        public async Task<int> RunAsync()
        {
            // https://identityserver4.readthedocs.io/en/latest/topics/logging.html#setup-for-serilog
            // more @ https://identityserver4.readthedocs.io/en/latest/topics/events.html
            System.Diagnostics.Activity.DefaultIdFormat = System.Diagnostics.ActivityIdFormat.W3C;
            try
            {
                Log.Information("Starting host");
                
                var builder = CreateHostBuilder(args);
                var host = builder.Build();

                await OnRunAsync(host);
                host.Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public abstract Task<int> OnRunAsync(IHost host);

        //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/web-host
        public IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.ConfigureKestrel(options => options.AddServerHeader = false);//TODO: examine best practices
                  webBuilder.
                   CaptureStartupErrors(true)
                   //https://github.com/serilog/serilog-aspnetcore#inline-initialization
                   .UseSerilog((hostBuilderContext, loggerConfiguration) =>
                      loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration)//using Serilog.Settings.Configuration
                   )//using Serilog.AspNetCore;

                   .ConfigureAppConfiguration((context, configurationBuilder) =>
                   {
                       Log.Information($"ContentRootPath: {context.HostingEnvironment.ContentRootPath}");
                       //configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);//TODO: examine how GBI hosting genvironment
                   })
                   .UseStartup<TStartup>();
              });
        }
    }
}
