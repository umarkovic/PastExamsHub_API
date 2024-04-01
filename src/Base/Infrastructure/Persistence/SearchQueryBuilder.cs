using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PastExamsHub.Base.Infrastructure.Persistence
{
    public class SearchQueryBuilder<TEntity> : ISearchQueryBuilder<TEntity> where TEntity : class
    {
        readonly DbSet<TEntity> DbSet;
        readonly string TableName;

        public SearchQueryBuilder(IDbContextResolver contextResolver)
        {
            var dbContext = contextResolver.GetContext();

            DbSet = dbContext.Set<TEntity>();

            var model = dbContext.Model;
            var entityTypes = model.GetEntityTypes();
            var entityType = entityTypes.First(t => t.ClrType == typeof(TEntity));
            TableName = entityType.GetTableName();
        }

        public IQueryable<TEntity> GetQuery(string searchText)
        {
            //consider .AsNoTracking();
            //AsNoTracking used per query

            if (string.IsNullOrEmpty(searchText))
            {
                return DbSet;
            }

            var sql = FormattableStringFactory.Create(
                "SELECT * FROM [" + TableName + "] WHERE CONTAINS(*, {0})",
                new object[] { searchText }
            );

            return DbSet.FromSqlInterpolated(sql);
        }
    }
}
