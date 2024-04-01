using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PastExamsHub.Authority.Application.Common.Interfaces;

namespace PastExamsHub.Authority.Application.Password.Command.ForgotPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
    {
        readonly IIdentityService IdentityService;

        public ResetPasswordCommandHandler(IIdentityService identityService)
        {
            IdentityService = identityService;
        }

        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            await IdentityService.ResetPasswordAsync(request.Email, request.Token, request.Password);
            
            return Unit.Value;
        }
    }
}
