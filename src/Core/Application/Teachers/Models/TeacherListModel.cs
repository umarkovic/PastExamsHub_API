using PastExamsHub.Core.Application.Courses.Models;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Teachers.Models
{
    public class TeacherListModel
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public List<string> Courses { get; set; }
        public int NumberOfCourses { get; set; }



        public static Expression<Func<User, TeacherListModel>> Projection
        {
            get
            {
                return user => new TeacherListModel()
                {
                    Uid = user.Uid,
                    Email = user.Email,
                    FullName = user.FirstName + " "+ user.LastName

                };
            }
        }
    }
}
