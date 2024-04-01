using MediatR;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Base.Domain.Common;

namespace PastExamsHub.Core.Application.Teachers.Queries.GetCollection
{
    public class GetTeachersQuery : PaginationSpecification, IRequest<GetTeachersQueryResult>
    {
        [OpenApiExclude]
        public string UserUid { get; set; }
    }
}
