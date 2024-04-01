using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastExamsHub.Authority.Application.Password.Command.ForgotPassword
{
    public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordCommandValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            //TODO: check if valid URL
            RuleFor(c => c.ReturnUrl)
                .NotEmpty();
        }
    }
}
