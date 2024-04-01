using MediatR;
using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Core.Application.ExamPeriods.Command.Create;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Command.Update
{
    public class UpdateExamPeriodCommand : ExamPeriodCommand, IRequest<UpdateExamPeriodCommandResult>
    {
        [OpenApiExclude]
        public string Uid { get; set; }

        [OpenApiExclude]
        public string UserUid { get; set; }
    }
}
