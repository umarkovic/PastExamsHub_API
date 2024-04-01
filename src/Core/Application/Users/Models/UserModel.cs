using PastExamsHub.Base.Domain.Enums;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Common.Users.Models
{
    public class UserModel
    {
        public string Uid { get; set; }
        public string Email { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public RoleType Role { get; set; }
        public int? Index { get; set; }
        public int? StudyYear { get; set; }
        public GenderType Gender { get; set; }



        public static Expression<Func<User, UserModel>> Projection
        {
            get
            {
                return user => new UserModel()
                {
                    Uid = user.Uid,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    Role = user.Role,
                    Index = user.Index,
                    StudyYear = user.StudyYear,

                };
            }
        }
    }
}
