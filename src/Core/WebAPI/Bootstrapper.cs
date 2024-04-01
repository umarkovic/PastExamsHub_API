using PastExamsHub.Base.WebAPI;
using PastExamsHub.Core.Infrastructure.Persistence;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PastExamsHub.Core.Application.Common.Interfaces;

namespace PastExamsHub.Core.WebAPI
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
                    var context = services.GetRequiredService<ICoreDbContext>();
                    //Serilog.Log.Error("CoreDbContext connection: {Connection}", (context as DbContext)?.Database?.GetDbConnection()?.ConnectionString);
                    await context.Migrate();
                }
            }

            return 0;
        }
    }
}
