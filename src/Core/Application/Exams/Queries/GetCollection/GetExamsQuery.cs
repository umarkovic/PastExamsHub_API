using MediatR;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Queries.GetCollection
{
    public class GetExamsQuery : PaginationSpecification, IRequest<GetExamsQueryResult>
    {
        [OpenApiExclude]
        public string UserUid { get; set; }
        public string ExamPeriodUid { get; set; }
        public string CourseUid { get; set; }
    }
}
