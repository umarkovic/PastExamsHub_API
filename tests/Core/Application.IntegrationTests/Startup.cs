
using GBI.EnterpriseServices.Storage.Application.UnitTests.Stub;
using GBI.EnterpriseServices.Storage.StorageApi.Application.Common.Interfaces;
using GBI.EnterpriseServices.Storage.StorageApi.Infrastructure.Braintree;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBI.EnterpriseServices.Storage.Application.UnitTests
{
    public class Startup : GBI.EnterpriseServices.Storage.StorageApi.WebApi.Startup
    {
        public Startup
        (
            IConfiguration configuration,
            IWebHostEnvironment environment
        ) : base 
        (
            configuration, 
            environment
        )
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddSingleton<ICurrentUserService, CurrentUserService>();
        }
    }
}
