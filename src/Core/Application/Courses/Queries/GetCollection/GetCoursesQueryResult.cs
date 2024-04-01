using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PastExamsHub.Core.Application.Courses.Models;

namespace PastExamsHub.Core.Application.Courses.Queries.GetCollection
{
    public class GetCoursesQueryResult 
    {
        public List<CourseModel> Courses { get; set; }

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
