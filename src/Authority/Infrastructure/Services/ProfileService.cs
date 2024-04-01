using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using PastExamsHub.Authority.Infrastructure.Persistence;
using PastExamsHub.Base.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PastExamsHub.Authority.Infrastructure.Identity;

namespace PastExamsHub.Authority.Infrastructure.Services
{
    //TODO: not needed?
    public class ProfileService : IProfileService
    {
        private readonly UserManager<IdentityApplicationUser> UserManager;

        public ProfileService(UserManager<IdentityApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //Back if you need additional claims from database 

            var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = subject.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;

            var user = await UserManager.FindByIdAsync(subjectId);

            if (user == null)
            {
                throw new ArgumentException("Invalid subject identifier");
            }

            //var claims = GetClaimsFromUser(user);
            //context.IssuedClaims = claims.ToList();


            context.IssuedClaims = context.Subject.Claims.ToList();
            //context.IssuedClaims.Add(new Claim("ssn", user.SSN)); //TODO: custom claims
        }

        async public Task IsActiveAsync(IsActiveContext context)
        {
            var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = subject.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;
            var user = await UserManager.FindByIdAsync(subjectId);

            context.IsActive = true; //TODO: back to false and read from database (user.LockoutEnabled?)
        }

        private IEnumerable<Claim> GetClaimsFromUser(IdentityApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.Id),
                new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            if (UserManager.SupportsUserEmail)
            {
                claims.AddRange(new[]
                {
                    new Claim(JwtClaimTypes.Email, user.Email),
                    new Claim(JwtClaimTypes.EmailVerified, user.EmailConfirmed ? "true" : "false", ClaimValueTypes.Boolean)
                });
            }

            if (UserManager.SupportsUserPhoneNumber && !string.IsNullOrWhiteSpace(user.PhoneNumber))
            {
                claims.AddRange(new[]
                {
                    new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber),
                    new Claim(JwtClaimTypes.PhoneNumberVerified, user.PhoneNumberConfirmed ? "true" : "false", ClaimValueTypes.Boolean)
                });
            }

            return claims;
        }
    }
}
