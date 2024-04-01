using PastExamsHub.Core.Application.Common.Users.Models;
using PastExamsHub.Core.Application.Teachers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Teachers.Queries.GetSingle
{
    public class GetTeacherQueryResult
    {
        public TeacherModel User { get; set; }
    }
}
