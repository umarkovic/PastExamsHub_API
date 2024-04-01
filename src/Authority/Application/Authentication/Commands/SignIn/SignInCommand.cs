using MediatR;
using System;

namespace PastExamsHub.Authority.Application.Authentication.Commands.SignIn
{
    public class SignInCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
