using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PastExamsHub.Base.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastExamsHub.Authority.Infrastructure.Persistence.DesignTime
{
    //https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation
    //https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext
    //https://www.benday.com/2017/12/19/ef-core-2-0-migrations-without-hard-coded-connection-strings/
    public abstract class DbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextFactory()
        {
            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments
            var environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ??
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
        }

        public TContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.ConfigureDbContext<TContext>(Configuration, null);

            return CreateNewInstance(optionsBuilder.Options);
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);
    }
}
