using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastExamsHub.Authority.Infrastructure.Persistence.DesignTime
{
    public class ConfigurationDbContextFactory : DbContextFactory<ConfigurationDbContext>
    {
        protected override ConfigurationDbContext CreateNewInstance(DbContextOptions<ConfigurationDbContext> options)
        {
            var storeOptions = new ConfigurationStoreOptions();
            storeOptions.ConfigureDbContext = (optionsBuilder => optionsBuilder.ConfigureDbContext<ConfigurationDbContext>(Configuration, null));

            return new ConfigurationDbContext(options, storeOptions);
        }
    }
}
