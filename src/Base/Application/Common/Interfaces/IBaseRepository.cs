using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Base.Application.Common.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity: DomainEntity
    { 
        Task<IEnumerable<TEntity>> FindByConditionAync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
        Task<TEntity> GetByUidAsync(string uid, CancellationToken cancellationToken);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> GetQuery(); //REVIEW: rename to StartQuery
        Task<TEntity> GetByUidOrThrowAsync(string estateUid, CancellationToken cancellationToken);
    }
}
