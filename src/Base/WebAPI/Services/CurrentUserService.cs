using PastExamsHub.Base.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Linq;
using PastExamsHub.Base.Domain.Enums;
using PastExamsHub.Base.Domain.Common;
using IdentityModel;
using System;

namespace PastExamsHub.Base.WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        string FindClaim(string type)
        {
            return _httpContextAccessor.HttpContext?
                .User?
                .Claims?
                .FirstOrDefault(x => string.Compare(x.Type, type, true) == 0)?
                .Value;
        }

        public ApplicationUser ApplicationUser
        {
            get
            {
                return new ApplicationUser()
                {
            
                    Email = FindClaim(JwtClaimTypes.Email),
                    PhoneNumber = FindClaim(JwtClaimTypes.PhoneNumber),
                    FirstName = FindClaim(JwtClaimTypes.GivenName),
                    LastName = FindClaim(JwtClaimTypes.FamilyName),
                    Role = this.Role
                };
            }
        }

        public string UserUid
        {
            get
            {
                return FindClaim(JwtClaimTypes.Subject);
            }
        }

        

        public RoleType Role
        {
            get
            {
                var role = FindClaim(JwtClaimTypes.Role);
                var roleType = RoleType.Unknown;
                Enum.TryParse<RoleType>(role, out roleType);
                return roleType;
            }
        }

        public bool IsInRole(string role)
        {
            return string.Compare(Role.ToString(), role, true) == 0;
        }
    }
}
