using MediatR;
using PastExamsHub.Base.Domain.Common;

namespace PastExamsHub.Core.Application.Users.Queries.GetSingle
{
    public class GetUserQuery : IRequest<GetUserQueryResult>
    {
        [OpenApiExclude]
        public string Uid { get; set; }

        [OpenApiExclude]
        public string UserUid { get; set; }
    }
}
