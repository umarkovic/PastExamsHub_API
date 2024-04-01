using MediatR;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Courses.Commands.Delete;
using PastExamsHub.Core.Application.ExamSoultions.Commands.Create;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Commands.Delete
{
    public class DeleteExamSolutionCommandHandler : IRequestHandler<DeleteExamSolutionCommand,DeleteExamSolutionCommandResult>
    {

        readonly ICoreDbContext DbContext;
        readonly IUsersRepository UsersRepository;
        readonly IExamsRepository ExamRepository;
        readonly IBaseRepository<ExamSolution> ExamSolutionRepository;
        readonly IFilesRepository FileRepository;
        public DeleteExamSolutionCommandHandler
        (
            IUsersRepository usersRepository,
            IExamsRepository examRepository,
            ICoreDbContext dbContext,
            IBaseRepository<ExamSolution> examSolutionRepository,
            IFilesRepository fileRepository

        )
        {

            UsersRepository = usersRepository;
            ExamRepository = examRepository;
            DbContext = dbContext;
            ExamSolutionRepository = examSolutionRepository;
            FileRepository = fileRepository;
        }

        public async Task<DeleteExamSolutionCommandResult> Handle(DeleteExamSolutionCommand command, CancellationToken cancellationToken)
        {
            var solution = await ExamSolutionRepository.GetByUidAsync(command.Uid, cancellationToken);


            solution.IsSoftDeleted = true;
            ExamSolutionRepository.Update(solution);
            await DbContext.SaveChangesAsync(cancellationToken);

            return new DeleteExamSolutionCommandResult { Uid = solution.Uid };
        }
    }
}
