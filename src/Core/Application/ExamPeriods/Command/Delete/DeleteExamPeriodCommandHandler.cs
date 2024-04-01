using MediatR;
using Microsoft.VisualBasic;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Command.Delete
{
    public class DeleteExamPeriodCommandHandler : IRequestHandler<DeleteExamPeriodCommand,DeleteExamPeriodCommandResult>
    {
        readonly ICoreDbContext DbContext;
        readonly IBaseRepository<ExamPeriod> ExamPeriodRepository;
        public DeleteExamPeriodCommandHandler
        (
            IBaseRepository<ExamPeriod> examPeriodRepository,
            ICoreDbContext dbContext

        )
        {
            ExamPeriodRepository = examPeriodRepository;
            DbContext = dbContext;
        }

        public async Task<DeleteExamPeriodCommandResult> Handle ( DeleteExamPeriodCommand command, CancellationToken cancellationToken )
        {
            var examPeriod = await ExamPeriodRepository.GetByUidAsync(command.Uid, cancellationToken);

            //COMPLETE: expand with Cascade delete or validation if exams are present

            ExamPeriodRepository.Delete(examPeriod);
            await DbContext.SaveChangesAsync(cancellationToken);

            return new DeleteExamPeriodCommandResult { Uid = examPeriod.Uid };
        }
    }
}
