using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastExamsHub.Authority.Infrastructure.Persistence.DesignTime
{
    public class PersistedGrantDbContextFactory : DbContextFactory<PersistedGrantDbContext>
    {
        protected override PersistedGrantDbContext CreateNewInstance(DbContextOptions<PersistedGrantDbContext> options)
        {
            var storeOptions = new OperationalStoreOptions();
            storeOptions.ConfigureDbContext = (optionsBuilder => optionsBuilder.ConfigureDbContext<PersistedGrantDbContext>(Configuration, null));
            
            return new PersistedGrantDbContext(options, storeOptions);
        }
    }
}
