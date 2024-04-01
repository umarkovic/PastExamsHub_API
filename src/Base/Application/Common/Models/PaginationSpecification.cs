using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Base.Application.Common.Models
{
    public abstract class PaginationSpecification
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }

        [OpenApiExclude]
        public string _searchText { get; set; }
        public virtual string SearchText
        {
            get => _searchText;
            set
            {
                //Optimized query for searching non adjesent words using *, AND with "" and string separator \
                if (!string.IsNullOrEmpty(value))
                {
                    var searchTerms = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(term => $"\"{term}*\"");

                    _searchText = string.Join(" AND ", searchTerms);
                }

            }
        }
    }
}
