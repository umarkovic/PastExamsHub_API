using MediatR;
using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Queries.GetSingle
{
    public class GetExamQuery : IRequest<GetExamQueryResult>
    {
        [OpenApiExclude]
        public string Uid { get; set; }
    }
}
