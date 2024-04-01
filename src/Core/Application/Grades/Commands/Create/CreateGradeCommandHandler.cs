using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Grades.Commands.Create
{
    public class CreateGradeCommandHandler : IRequestHandler<CreateGradeCommand, CreateGradeCommandResult>
    {
        readonly IUsersRepository UsersRepository;
        readonly IBaseRepository<ExamSolution> ExamSolutionsRepository;
        readonly IBaseRepository<ExamSolutionGrade> GradesRepository;
        readonly ICoreDbContext DbContext;

        public CreateGradeCommandHandler
        (
            IUsersRepository usersRepository,
            IBaseRepository<ExamSolution> examSolutionsRepository,
            IBaseRepository<ExamSolutionGrade> gradesRepository,
            ICoreDbContext dbContext

        )
        {
            ExamSolutionsRepository = examSolutionsRepository;
            UsersRepository= usersRepository;
            GradesRepository = gradesRepository;
            DbContext = dbContext;
        }



        public async Task<CreateGradeCommandResult> Handle ( CreateGradeCommand command, CancellationToken cancellationToken)
        {
            int grade = command.IsPositive ? 1 : -1;

            var solution = await ExamSolutionsRepository.GetQuery().Where(x => x.Uid == command.ExamSolutionUid).SingleOrDefaultAsync();
            var user = await UsersRepository.GetByUidAsync(command.UserUid, cancellationToken);

            if(command.IsUpdate)
            {
                var existingGrade = GradesRepository.GetQuery().Where(x=>x.Solution == solution && x.User == user).SingleOrDefault();
                if(existingGrade.Grade == -1 && command.IsPositive)
                {
                    existingGrade.Grade = 1;
                    solution.Grade += 2;
                    ExamSolutionsRepository.Update(solution);
                    GradesRepository.Update(existingGrade);
                }
                else if (existingGrade.Grade == 1 && !command.IsPositive)
                {
                    existingGrade.Grade = -1;
                    solution.Grade -= 2;
                    ExamSolutionsRepository.Update(solution);
                    GradesRepository.Update(existingGrade);
                }

                await DbContext.SaveChangesAsync(cancellationToken);
            }
               

            var calculatedGrade = GradesRepository.GetQuery().Where(x => x.Solution == solution).Sum(x => x.Grade);
            calculatedGrade = !command.IsUpdate ? calculatedGrade + grade : calculatedGrade;

            solution.GradeCount = !command.IsUpdate ? solution.GradeCount+1 : solution.GradeCount;
            solution.Grade = calculatedGrade;
            ExamSolutionsRepository.Update(solution);

            if (!command.IsUpdate)
            {
                var newGrade = new ExamSolutionGrade(user, solution, grade);
                GradesRepository.Insert(newGrade);
            }
            await DbContext.SaveChangesAsync(cancellationToken);


            return new CreateGradeCommandResult { Grade = 1, Uid = null };
        }
    }
}
