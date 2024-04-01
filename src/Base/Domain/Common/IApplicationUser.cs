using PastExamsHub.Base.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastExamsHub.Base.Domain.Common
{
    public interface IApplicationUser
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleType Role { get; set; }

    }
}
