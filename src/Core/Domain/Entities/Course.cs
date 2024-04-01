using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Domain.Entities
{
    public class Course : DomainEntity
    {
        //COMPLETE: possibly expand course with semester
        public string Name { get; set; }
        public CourseType CourseType { get; set; }
        public StudyType StudyType { get; set; }
        public  User Lecturer { get; set; }
        public int StudyYear { get; set; }
        public int  Semester { get; set; }
        public int ESPB { get; set; }
        public User CreatedBy { get; set; }
        public bool IsSoftDeleted { get; set; }

        public Course()
        {
            Uid = Guid.NewGuid().ToString();
        }

        public Course
        (
            string name,
            CourseType type,
            int year,
            int semester,
            int espb,
            User createdBy
        )
        {
            Uid = Guid.NewGuid().ToString();
            Name = name;
            CourseType = type;
            StudyYear = year;
            Semester = semester;
            ESPB = espb;
            IsSoftDeleted = false;
            CreatedBy = createdBy;
        }


        public void UpdateFrom(Course course)
        {
            Name = course.Name;
            //StudyType = course.StudyType;
            ESPB = course.ESPB;
            StudyYear = course.StudyYear;
            Semester = course.Semester;
            CourseType = course.CourseType;

        }
    }
}
