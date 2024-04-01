using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Base.Application.Common.Interfaces
{
    public interface ISearchQueryBuilder<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> GetQuery(string searchText = null);
    }
}
