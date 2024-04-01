using MediatR;
using Microsoft.Extensions.Configuration;
using PastExamsHub.Authority.Application.Common.Interfaces;
using PastExamsHub.Base.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Authority.Application.Authentication.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, Unit>
    {
        readonly IIdentityService IdentityService;

        public SignUpCommandHandler
       (
           IIdentityService identityService,
           IEmailTemplateService emailTemplateService
       )
        {
            IdentityService = identityService;
        }

        public async Task<Unit> Handle(SignUpCommand command, CancellationToken cancellationToken)
        {
            await IdentityService.SignUpAsync(command.Email, command.Password, command.FirstName, command.LastName, command.IsTeacher, cancellationToken);

            return MediatR.Unit.Value;
        }
    }
}
