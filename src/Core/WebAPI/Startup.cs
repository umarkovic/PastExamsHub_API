using PastExamsHub.Core.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Infrastructure.Services;
using PastExamsHub.Core.WebAPI.SignalR;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.Connections;

namespace PastExamsHub.Core.WebAPI
{
    public class Startup : Base.WebAPI.Startup
    {
        public Startup
        (
            IConfiguration configuration,
            IWebHostEnvironment environment
        ) 
            : base(configuration, environment)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            Application.Startup.ConfigureServices(services, Configuration, Environment);
            Infrastructure.Startup.ConfigureServices(services, Configuration, Environment);

            base.ConfigureServices(services);

            var connectionString = Configuration.GetConnectionString(nameof(CoreDbContext));//TODO: should reside in Infrastructure
            //services.AddHangfire(connectionString);

            //TODO: switch to Newtonsoft.Json or MessagePack
            services.AddSignalR().AddNewtonsoftJsonProtocol(options =>
            {
                options.PayloadSerializerSettings.Converters.Add(new StringEnumConverter());//using Newtonsoft.Json.Converters;
                options.PayloadSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;//was System.Text.Json.Serialization.ReferenceHandler.Preserve;
                //TODO: for ReferenceLoopHandling.Ignore, smart deserialization needed on FE https://stackoverflow.com/questions/40148295/how-to-deal-with-json-net-object-references-in-the-browser
                //options.PayloadSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;//was System.Text.Json.Serialization.ReferenceHandler.Preserve;
                //options.PayloadSerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                //TODO: make common in Base.Startup
            });//.AddMessagePackProtocol();//TODO: consider

            services.AddSingleton<IInMemoryConnectionStorage<string>, InMemoryConnectionStorage<string>>();


        }

        protected override void ConfigureServicesForHealthChecks(IHealthChecksBuilder healthChecksBuilder)
        {
            base.ConfigureServicesForHealthChecks(healthChecksBuilder);

            healthChecksBuilder.AddDbContextCheck<CoreDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<EventsHub>("/events", hubOptions => hubOptions.Transports = HttpTransportType.WebSockets);
            });
            
        }
    }
}
