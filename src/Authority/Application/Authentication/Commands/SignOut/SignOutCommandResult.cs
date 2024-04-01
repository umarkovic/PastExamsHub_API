using System;
using System.Collections.Generic;
using System.Text;

namespace PastExamsHub.Authority.Application.Authentication.Commands.SignOut
{
    public class SignOutCommandResult
    {
        public string PostLogoutRedirectUri { get; set; }
    }
}
