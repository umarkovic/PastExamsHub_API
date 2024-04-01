using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Base.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace PastExamsHub.Authority.Infrastructure.Identity
{
    //IMPORTANT: only for persistence
    public class IdentityApplicationUser : IdentityUser, IApplicationUser
    {


        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; } 

        public RoleType Role { get; set; }

      
     

        internal void UpdateFrom(IApplicationUser applicationUser)
        {
            UserName = applicationUser.Email;
            Email = applicationUser.Email;
            PhoneNumber = applicationUser.PhoneNumber;
            FirstName = applicationUser.FirstName;
            LastName = applicationUser.LastName;
            Role = applicationUser.Role;
         


        }
    }
}
