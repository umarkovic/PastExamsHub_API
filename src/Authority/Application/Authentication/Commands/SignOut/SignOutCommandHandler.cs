using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PastExamsHub.Authority.Application.Common.Interfaces;

namespace PastExamsHub.Authority.Application.Authentication.Commands.SignOut
{
    public class SignOutCommandHandler : IRequestHandler<SignOutCommand, SignOutCommandResult>
    {
        readonly IIdentityService IdentityService;


        public SignOutCommandHandler(IIdentityService identityService)
        {
            IdentityService = identityService;
        }

        public async Task<SignOutCommandResult> Handle(SignOutCommand command, CancellationToken cancellationToken)
        {
            var uri = await IdentityService.SignOutAsync(command.LogoutId);

            return new SignOutCommandResult()
            {
                PostLogoutRedirectUri = uri
            };
        }
    }
}
