using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Authority.Application.Common.Interfaces;

namespace PastExamsHub.Authority.Infrastructure.Persistence
{
    //https://github.com/IdentityServer/IdentityServer4/blob/main/src/EntityFramework.Storage/src/DbContexts/PersistedGrantDbContext.cs
    public class PersistedGrantDbContext : IdentityServer4.EntityFramework.DbContexts.PersistedGrantDbContext<PersistedGrantDbContext>, IPersistedGrantDbContext
    {
        //private readonly OperationalStoreOptions _storeOptions;

        public PersistedGrantDbContext
        (
            DbContextOptions<PersistedGrantDbContext> options, 
            OperationalStoreOptions storeOptions
        )
            : base(options, Configure(storeOptions))
        {
            //_storeOptions = storeOptions;
        }

        static OperationalStoreOptions Configure(OperationalStoreOptions options)
        {
            options.DefaultSchema = nameof(IdentityServer4);
            return options;
        }

        public async Task Migrate()
        {
            if (Database.IsInMemory())
            {
                return;
            }

            await Database.MigrateAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ConfigurePersistedGrantContext(_storeOptions);

            base.OnModelCreating(modelBuilder);
        }
    }
}
