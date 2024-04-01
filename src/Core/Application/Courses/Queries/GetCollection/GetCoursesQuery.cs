using MediatR;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Queries.GetCollection
{
    public class GetCoursesQuery : PaginationSpecification, IRequest<GetCoursesQueryResult>
    {
        [OpenApiExclude]
        public string UserUid { get; set; }
        public int? StudyYear { get; set; }
        public CourseFilter? Filter { get; set; }
    }
}
