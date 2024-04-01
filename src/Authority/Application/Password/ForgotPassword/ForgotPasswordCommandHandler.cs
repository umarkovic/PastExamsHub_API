using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using PastExamsHub.Authority.Application.Common.Interfaces;
using PastExamsHub.Base.Application.Common.Interfaces;

namespace PastExamsHub.Authority.Application.Password.Command.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Unit>
    {
        readonly Options.ForgotPassword Options;
        readonly IIdentityService IdentityService;
        readonly IEmailTemplateService EmailTemplateService;

        public ForgotPasswordCommandHandler
        (
            IOptions<Options.ForgotPassword> options,
            IIdentityService identityService,
            IEmailTemplateService emailTemplateService
        )
        {
            Options = options.Value;
            IdentityService = identityService;
            EmailTemplateService = emailTemplateService;
        }

        public async Task<Unit> Handle(ForgotPasswordCommand command, CancellationToken cancellationToken)
        {
            if(Options.SendGridTemplateId == null)
            {
                return Unit.Value;
            }

            var user = await IdentityService.FindByEmailAsync(command.Email);
            var token = await IdentityService.GeneratePasswordResetTokenAsync(command.Email);

            var encodedReturnUrl = System.Net.WebUtility.UrlEncode(command.ReturnUrl);
            var encodedToken = System.Net.WebUtility.UrlEncode(token);

            var templateData = new 
            {
                Name = $"{user.FirstName} {user.LastName}",
                RedirectUrl = $"{Options.RedirectUrl}?email={command.Email}&returnUrl={encodedReturnUrl}&token={encodedToken}"
            };

            await EmailTemplateService.SendAsync(command.Email, Options.SendGridTemplateId, templateData);

            return Unit.Value;
        }
    }
}
