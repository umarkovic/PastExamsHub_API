using MediatR;

namespace PastExamsHub.Authority.Application.Password.Command.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<Unit>
    {
        public string Email { get; set; }
        public string ReturnUrl { get; set; }
    }
}
