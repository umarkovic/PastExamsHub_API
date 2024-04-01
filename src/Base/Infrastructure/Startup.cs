using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Infrastructure.Identity;
using PastExamsHub.Base.Infrastructure.Services;
using PastExamsHub.Base.Infrastructure.Persistence;

namespace PastExamsHub.Base.Infrastructure
{
    public static class Startup
    {
        public static void ConfigureDbContext<TDbContext>
        (
            this DbContextOptionsBuilder options,
            IConfiguration configuration,
            IHostEnvironment environment,
            bool splitQueries = false
        ) 
            where TDbContext: DbContext
        {
            var dbContextName = typeof(TDbContext).Name;
            var useInMemoryDatabase = configuration.GetValue<bool>("UseInMemoryDatabase");//TODO: from settings

            var connectionString = configuration.GetConnectionString(dbContextName);
            var migrationsAssembly = typeof(TDbContext).GetTypeInfo().Assembly.GetName().Name;

            if (useInMemoryDatabase)
            {
                options.UseInMemoryDatabase(dbContextName);
            }
            else
            {
				options.UseSqlServer(
                //options.UseNpgsql( //using Npgsql.EntityFrameworkCore.PostgreSQL
                    connectionString,
                    sql =>
                    {
                        //https://github.com/npgsql/efcore.pg/issues/761
                        //sql.SetPostgresVersion(new System.Version(11, 10));
                        sql.MigrationsAssembly(migrationsAssembly);
                        sql.EnableRetryOnFailure(3);
                        //TODO: handle resiliency (use Polly instead?)
                        //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                        //options.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                        if (splitQueries)
                        {
                            sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        }
                    }
                );
            }

            if (environment?.IsDevelopment() ?? false)
            {
                options.EnableSensitiveDataLogging();//TODO: turn off in PROD
            }
        }

        public static void ConfigureServices
        (
            IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment
        )
        {
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddScoped(typeof(ISearchQueryBuilder<>), typeof(SearchQueryBuilder<>));
        }

        /*
        public static void AddConfigurationStore(this IIdentityServerBuilder builder, Action<ConfigurationStoreOptions> storeOptionsAction = null)
        {

        }
        */

        /*
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
        */
    }
}
