using MediatR;
using System;

namespace PastExamsHub.Authority.Application.Authentication.Commands.SignOut
{
    public class SignOutCommand : IRequest<SignOutCommandResult>
    {
        public string LogoutId { get; set; }
    }
}
