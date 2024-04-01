using MediatR;
using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Commands.Delete
{
    public class DeleteCourseCommand : IRequest<DeleteCourseCommandResult>
    {
        [OpenApiExclude]
        public string UserUid { get; set; }
        public string Uid { get; set; }
    }
}
