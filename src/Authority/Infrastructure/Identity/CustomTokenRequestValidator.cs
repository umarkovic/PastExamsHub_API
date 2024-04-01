using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Authority.Infrastructure.Identity
{
    public class CustomTokenRequestValidator : ICustomTokenRequestValidator
    {
        public Task ValidateAsync(CustomTokenRequestValidationContext context)
        {
            //Back for remember me implementation
            //if (context.Result.ValidatedRequest.GrantType == GrantType.AuthorizationCode)
            //{
            //    var rememberMe = context.Result?.ValidatedRequest?.Subject?.Claims?.Where(x => x.Type == "remember_me").FirstOrDefault()?.Value;
            //    if (rememberMe != null && context.Result?.ValidatedRequest?.Client?.AbsoluteRefreshTokenLifetime != null && rememberMe.Equals("True"))
            //    {
            //        context.Result.ValidatedRequest.Client.AbsoluteRefreshTokenLifetime = 30000;
            //    }
            //    else
            //    {
            //        context.Result.ValidatedRequest.Client.AbsoluteRefreshTokenLifetime = 120000;
            //    }
            //}

            return Task.FromResult(0);
        }
    }
}
