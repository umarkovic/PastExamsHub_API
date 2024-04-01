using FluentValidation;

namespace PastExamsHub.Authority.Application.Password.Command.ForgotPassword
{
    class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            //TODO: password strength rules
            RuleFor(x => x.Password)
                .NotEmpty();

            RuleFor(x => x.Token)
                .NotEmpty();
        }
    }
}
