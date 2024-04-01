using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Base.Infrastructure.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace PastExamsHub.Base.Infrastructure.Persistence
{
    public abstract class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        protected IDbContextTransaction CurrentTransaction { get; private set; }

        protected readonly ICurrentUserService CurrentUserService;
        protected readonly IDateTime DateTime;
        protected readonly IDomainEventService DomainEventService;

        public ApplicationDbContext
        (
            DbContextOptions options,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService,
            IDateTime dateTime
        )
            : base(options)
        {
            this.CurrentUserService = currentUserService;
            this.DomainEventService = domainEventService;
            this.DateTime = dateTime;
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.AddAuditTrailForCreate(CurrentUserService.UserUid, DateTime.Now);
                        break;
                    case EntityState.Modified:
                        entry.Entity.AddAuditTrailForUpdate(CurrentUserService.UserUid, DateTime.Now);
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;//IMPORTANT: change hard to soft delete
                        entry.Entity.AddAuditTrailForDelete(CurrentUserService.UserUid, DateTime.Now);
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents();

            return result;
        }

        private async Task DispatchEvents()
        {
            while (true)
            {
                var domainEventEntity = ChangeTracker.Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .Where(domainEvent => !domainEvent.IsPublished)
                    .FirstOrDefault();
                if (domainEventEntity == null) break;

                domainEventEntity.IsPublished = true;
                await DomainEventService.Publish(domainEventEntity);
            }
        }

        public async Task BeginTransactionAsync()
        {
            if (CurrentTransaction != null)
            {
                return;
            }

            CurrentTransaction = await base.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);

                CurrentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (CurrentTransaction != null)
                {
                    CurrentTransaction.Dispose();
                    CurrentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                CurrentTransaction?.Rollback();
            }
            finally
            {
                if (CurrentTransaction != null)
                {
                    CurrentTransaction.Dispose();
                    CurrentTransaction = null;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());

            base.OnModelCreating(builder);
        }

        public virtual async Task Migrate()
        {
            if(!OnMigrate())
            {
                return;
            }
            
            await Database.MigrateAsync();
        }

        public abstract bool OnMigrate();
    }
}
