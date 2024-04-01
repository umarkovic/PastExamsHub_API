using MediatR;
using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Queries.GetSingle
{
    public class GetCourseQuery : IRequest<GetCourseQueryResult>
    {
        [OpenApiExclude]
        public string Uid { get; set; }

        [OpenApiExclude]
        public string UserUid { get; set; }
    }
}
