using PastExamsHub.Base.Domain.Enums;
using PastExamsHub.Core.Application.Courses.Models;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PastExamsHub.Core.Application.Teachers.Models
{
    public class TeacherModel
    {

        public string Uid { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleType Role { get; set; }
        public GenderType Gender { get; set; }
        public List<CourseListModel> Courses { get; set; }
        public int NumberOfCourses { get; set; }



        public static Expression<Func<User, TeacherModel>> Projection
        {
            get
            {
                return user => new TeacherModel()
                {
                    Uid = user.Uid,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    Role = user.Role,
                };
            }
        }
    }
}

