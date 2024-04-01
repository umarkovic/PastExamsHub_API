using MediatR;
using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Command.Delete
{
    public class DeleteExamPeriodCommand : IRequest<DeleteExamPeriodCommandResult>
    {
        [OpenApiExclude]
        public string Uid { get; set; }

        [OpenApiExclude]
        public string UserUid { get; set; }
    }
}
