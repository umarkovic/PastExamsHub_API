using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PastExamsHub.Authority.Application.Common.Interfaces;


namespace PastExamsHub.Authority.Application.Authentication.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand>
    {
        readonly IIdentityService IdentityService;

        public SignInCommandHandler(IIdentityService identityService)
        {
            IdentityService = identityService;
        }

        public async Task<Unit> Handle(SignInCommand command, CancellationToken cancellationToken)
        {
            await IdentityService.SignInAsync(command.Email, command.Password, command.ReturnUrl);

            return Unit.Value;
        }
    }
}
