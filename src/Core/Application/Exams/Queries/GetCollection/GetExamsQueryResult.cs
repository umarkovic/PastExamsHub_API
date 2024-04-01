using PastExamsHub.Core.Application.Exams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Queries.GetCollection
{
    public class GetExamsQueryResult 
    {
        public List<ExamModel> Exams { get; set; }

        #region Pagination
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }

        #endregion Paginaton
    }
}
