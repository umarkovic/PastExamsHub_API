using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastExamsHub.Authority.Application.Authentication.Commands.SignOut
{
    public class SignOutCommandValidator : AbstractValidator<SignOutCommand>
    {

        public SignOutCommandValidator()
        {
            RuleFor(c => c.LogoutId)
                .NotEmpty();
        }
    }
}
