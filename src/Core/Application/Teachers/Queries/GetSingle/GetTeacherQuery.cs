using MediatR;
using PastExamsHub.Base.Domain.Common;

namespace PastExamsHub.Core.Application.Teachers.Queries.GetSingle
{
    public class GetTeacherQuery : IRequest<GetTeacherQueryResult>
    {
        [OpenApiExclude]
        public string Uid { get; set; }

        [OpenApiExclude]
        public string UserUid { get; set; }
    }
}
