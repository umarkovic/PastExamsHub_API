using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Exceptions;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Domain.Common;

namespace PastExamsHub.Base.Infrastructure.Persistence
{
    public class BaseRepository<TDbContextType, TEntity> : IBaseRepository<TEntity>
        where TDbContextType : IApplicationDbContext
        where TEntity : DomainEntity
    {
        protected readonly DbContext DbContext;

        public BaseRepository(TDbContextType dbContext)
        {
            DbContext = dbContext as DbContext;
            if(DbContext == null)
            {
                throw new ArgumentException("Not and instance of DbContext", nameof(dbContext));
            }
        }

        public virtual IQueryable<TEntity> GetQuery()
        {
            return DbContext.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> FindByConditionAync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await GetQuery().Where(predicate).ToArrayAsync(cancellationToken);
        }

        public async Task<TEntity> GetByUidAsync(string uid, CancellationToken cancellationToken)
        {
            return await GetQuery().Where(x => x.Uid == uid).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<TEntity> GetByUidOrThrowAsync(string uid, CancellationToken cancellationToken)
        {
            var entity = await GetByUidAsync(uid,cancellationToken);
            if(entity == null)
            {
                throw new NotFoundException(typeof(TEntity).Name, uid);
            }

            return entity;
        }

        public void Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
