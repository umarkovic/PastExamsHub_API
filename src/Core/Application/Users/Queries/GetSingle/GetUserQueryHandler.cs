using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Users.Models;
using PastExamsHub.Core.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Users.Queries.GetSingle
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryResult>
    {
        private readonly IUsersRepository UsersRepository;
        public GetUserQueryHandler
        (
            IUsersRepository usersRepository
        )
        {
            UsersRepository = usersRepository;
        }


        public async Task<GetUserQueryResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var result = await UsersRepository
                .GetQuery()
                .Where(x => x.Uid == request.Uid)
                .Select(UserModel.Projection)
                .FirstOrDefaultAsync(cancellationToken);

            return new GetUserQueryResult { User = result };
        }
    }
}
