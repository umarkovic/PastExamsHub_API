﻿using MediatR;
using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Commands.Delete
{
    public class DeleteExamSolutionCommand : IRequest<DeleteExamSolutionCommandResult>
    {
        [OpenApiExclude]
        public string UserUid { get; set; }

        [OpenApiExclude]
        public string Uid { get; set; }
    }
}
