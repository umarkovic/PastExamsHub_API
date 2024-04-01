using MediatR;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Core.Application.Courses.Queries.GetCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Queries.GetCollection
{
    public class GetExamPeriodsQuery : PaginationSpecification , IRequest<GetExamPeriodsQueryResult>
    {
        [OpenApiExclude]
        public string Uid { get; set; }

        [OpenApiExclude]
        public string UserUid { get; set; }
        public ExamPeriodFilter Filter { get; set; }
    }
}
