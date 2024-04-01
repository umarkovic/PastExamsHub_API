using PastExamsHub.Base.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace PastExamsHub.Base.Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static void ThrowOnFailure(this SignInResult result)
        {
            if (result.Succeeded)
            {
                return;
            }

            throw new Exception("Sign in failed");
        }

        public static void ThrowOnFailure(this IdentityResult result)
        {
            if(result.Succeeded)
            { 
                return; 
            }
            
            var message = string.Join(Environment.NewLine, result.Errors.Select(e => $"{e.Code}: {e.Description}"));
            throw new Exception("Identity operation failed: " + Environment.NewLine + message);
        }

        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => $"{e.Code}: {e.Description}"));
        }
    }
}