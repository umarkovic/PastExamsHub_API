using MediatR;

namespace PastExamsHub.Authority.Application.Password.Command.ForgotPassword
{
    public class ResetPasswordCommand : IRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
