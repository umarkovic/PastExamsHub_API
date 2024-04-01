using MediatR;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Queries.GetCollection
{
    public class GetExamSolutionsQuery : PaginationSpecification, IRequest<GetExamSolutionsQueryResult>
    {
        [OpenApiExclude]
        public string UserUid { get; set; }
        public string ExamUid { get; set; }
    }
}
