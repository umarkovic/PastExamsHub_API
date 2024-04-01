using MediatR;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.ExamPeriods.Command.Create;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Command.Update
{
    internal class UpdateExamPeriodCommandHandler : IRequestHandler<UpdateExamPeriodCommand, UpdateExamPeriodCommandResult>
    {
        readonly ICoreDbContext DbContext;
        readonly IBaseRepository<ExamPeriod> ExamPeriodRepository;
        public UpdateExamPeriodCommandHandler
        (
            IBaseRepository<ExamPeriod> examPeriodRepository,
            ICoreDbContext dbContext

        )
        {
            ExamPeriodRepository = examPeriodRepository;
            DbContext = dbContext;
        }
        public async Task<UpdateExamPeriodCommandResult> Handle(UpdateExamPeriodCommand command, CancellationToken cancellationToken)
        {
            var destination = await ExamPeriodRepository.GetByUidAsync(command.Uid, cancellationToken);
           

            var source = new ExamPeriod
            {
                Name = command.Name,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                PeriodType= command.PeriodType,

            };

            destination.UpdateFrom(source);

            await DbContext.SaveChangesAsync(cancellationToken);

            return new UpdateExamPeriodCommandResult { };
        }
    }
}
