using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastExamsHub.Authority.Application.Authentication.Commands.SignIn
{
    public class SignInCommandValidator : AbstractValidator<SignInCommand>
    {

        public SignInCommandValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.Password)
                .NotEmpty();

            RuleFor(c => c.ReturnUrl)
               .NotEmpty();
        }
    }
}
