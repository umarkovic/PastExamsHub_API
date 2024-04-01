using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Base.Domain.Enums;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Domain.Entities
{
    public class User : DomainEntity
    {
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public RoleType Role { get; set; }
        public int? Index { get; set; }
        public int? StudyYear { get; set; }
        public GenderType Gender { get; set; }
        public string FullName { get; set; }


        public void UpdateLecturer(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Gender = user.Gender;
            FullName = user.FirstName + " " + user.LastName;
            


        }

        public void UpdateStudent(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Gender = user.Gender;
            Index = user.Index;
            StudyYear= user.StudyYear;
            FullName = user.FirstName + " " + user.LastName;

        }

    }
}
