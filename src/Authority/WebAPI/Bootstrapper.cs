using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PastExamsHub.Authority.Infrastructure.Persistence;
using PastExamsHub.Base.Infrastructure.Identity;
using PastExamsHub.Base.WebAPI;
using Microsoft.AspNetCore.Hosting;
using PastExamsHub.Authority.Application.Common.Interfaces;

namespace PastExamsHub.Authority.WebAPI
{
    public class Bootstrapper : BootstrapperBase<Startup>
    {
        public Bootstrapper(string[] args) : base(args)
        {
        }

        public override async Task<int> OnRunAsync(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                //TODO: avoid antipatern
                var services = scope.ServiceProvider;

                //TODO: consider IdentityServerDataProtectionDbContext : DbContext, IDataProtectionKeyContext
                {
                    var context = services.GetRequiredService<IAuthorityDbContext>();
                    await context.Migrate();
                }

                {
                    var context = services.GetRequiredService<IConfigurationDbContext>();
                    await context.Migrate();
                }
                {
                    var context = services.GetRequiredService<IPersistedGrantDbContext>();
                    await context.Migrate();
                }
            }

            return 0;
        }
    }
}
