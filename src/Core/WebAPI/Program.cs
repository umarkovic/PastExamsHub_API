using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace PastExamsHub.Core.WebAPI
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
