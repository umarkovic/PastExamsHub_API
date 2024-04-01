using MediatR;
using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Core.Application.Courses.Models;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Teachers.Commands.Update
{
    public class UpdateTeacherCommand : IRequest<UpdateTeacherCommandResult>
    {
        [OpenApiExclude]
        public string UserUid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public List<CourseListModel> Courses { get; set; }
    }
}
