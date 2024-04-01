using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.ExamPeriods;
using PastExamsHub.Core.Application.Exams.Models;
using PastExamsHub.Core.Application.Exams.Queries.GetSingle;
using PastExamsHub.Core.Application.ExamSoultions.Models;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Queries.GetCollection
{
    public class GetExamSolutionsQueryHandler : IRequestHandler<GetExamSolutionsQuery,GetExamSolutionsQueryResult>
    {


        readonly IExamsRepository ExamsRepository;
        readonly IBaseRepository<ExamSolution> ExamSolutionsRepository;
        readonly ICoreDbContext DbContext;
        public GetExamSolutionsQueryHandler
        (
            IExamsRepository examsRepository,
            IBaseRepository<ExamSolution> examSolutionsRepository,
            ICoreDbContext dbContext
        )
        {
            ExamsRepository = examsRepository;
            ExamSolutionsRepository = examSolutionsRepository;
            DbContext = dbContext;
        }


        public async Task<GetExamSolutionsQueryResult> Handle(GetExamSolutionsQuery request, CancellationToken cancellationToken)
        {

            var currentUser = await (from u in DbContext.Users where u.Uid == request.UserUid select u).FirstOrDefaultAsync();

            var solutions =  (
                from es in DbContext.ExamSolutions
                join esg in DbContext.ExamSolutionGrades.Where(x => x.User.Uid == currentUser.Uid) on es.Id equals esg.Solution.Id into esg_join
                from _esg in esg_join.DefaultIfEmpty()
                join f in DbContext.Files on es.File.Id equals f.Id
                join e in DbContext.Exams on es.Exam.Id equals e.Id
                join c in DbContext.Courses on e.Course.Id equals c.Id
                join ep in DbContext.ExamPeriods on e.Period.Id equals ep.Id
                join u in DbContext.Users on es.User.Id equals u.Id
                where e.Uid == request.ExamUid &&
                es.IsSoftDeleted == false
                orderby es.CreatedDateTimeUtc descending
                select new ExamSolutionModel
                {
                    Uid = es.Uid,
                    OwnerUid = u.Uid,
                    CreatedDateTimeUtc = es.CreatedDateTimeUtc,
                    OwnerFirstName = u.FirstName,
                    OwnerLastName = u.LastName,
                    OwnerRole = u.Role,
                    FileType = f.Type,
                    TaskNumber = es.TaskNumber,
                    GradeCount = es.GradeCount,
                    Grade = es.Grade,
                    OwnerStudyYear = u.StudyYear,
                    CourseName = c.Name,
                    Type = e.Type,
                    PeriodName = ep.Name,
                    PeriodType = ep.PeriodType,
                    SoulutionComment = es.Comment,
                    IsEditAndDeleteAllowed = u.Uid == currentUser.Uid,
                    IsAlreadyGraded = _esg != null ? true : false,
                    IsPositiveGraded = _esg != null ? _esg.Grade==1 ? true : false : null,

                });

            //COMPLETE: Add grade calculation for exam soultions in ExamSolutions
            //COMPLETE: add for each row, IsGradePosted by checking currentUserUid if exist in ExamSolutionGrade table
            var results = await PaginationResult<ExamSolutionModel>.From(solutions, request.PageNumber, request.PageSize);


            return new GetExamSolutionsQueryResult
            {
                Solutions = results.Items,
                TotalCount = results.TotalCount,
                PageSize = results.PageSize,
                CurrentPage = results.CurrentPage,
                TotalPages = results.TotalPages,
                HasNext = results.HasNext,
                HasPrevious = results.HasPrevious
            };
        }
    }
}
