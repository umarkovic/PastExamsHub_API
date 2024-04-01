using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Queries.GetCollection
{
    public class CourseFilter
    {
        public string TeacherUid { get; set; }
        public CourseType Type { get; set; }
    }
}
