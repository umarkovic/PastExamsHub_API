using MediatR;
using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Grades.Commands.Create
{
    public class CreateGradeCommand : IRequest<CreateGradeCommandResult>
    {

        [OpenApiExclude]
        public string UserUid { get; set; }
        public string ExamSolutionUid { get; set; }
        public bool IsPositive { get; set; }
        public bool  IsUpdate { get; set; }
    }
}
