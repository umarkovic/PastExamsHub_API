using MediatR;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using OneOf.Types;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.ExamSoultions.Models;
using PastExamsHub.Core.Application.ExamSoultions.Queries.GetCollection;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Queries.GetSingle
{
    public class GetExamSolutionQueryHandler : IRequestHandler<GetExamSolutionQuery, GetExamSolutionQueryResult>
    {

        readonly IExamsRepository ExamsRepository;
        readonly IBaseRepository<ExamSolution> ExamSolutionsRepository;
        readonly ICoreDbContext DbContext;
        public GetExamSolutionQueryHandler
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

        public async Task<GetExamSolutionQueryResult> Handle(GetExamSolutionQuery request, CancellationToken cancellationToken)
        {

            var currentUser = await (from u in DbContext.Users where u.Uid == request.UserUid select u).FirstOrDefaultAsync();

            var solution = await (
                from es in DbContext.ExamSolutions
                join esg in DbContext.ExamSolutionGrades.Where(x => x.User.Uid == currentUser.Uid) on es.Id equals esg.Solution.Id into esg_join
                from _esg in esg_join.DefaultIfEmpty()
                join f in DbContext.Files on es.File.Id equals f.Id
                join e in DbContext.Exams on es.Exam.Id equals e.Id
                join c in DbContext.Courses on e.Course.Id equals c.Id
                join ep in DbContext.ExamPeriods on e.Period.Id equals ep.Id
                join u in DbContext.Users on es.User.Id equals u.Id
                where es.Uid == request.Uid &&
                es.IsSoftDeleted == false
                select new ExamSolutionFileModel
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
                    IsPositiveGraded = _esg != null ? _esg.Grade == 1 ? true : false : null,

                }).SingleOrDefaultAsync();

                        var file = await (
                                          from es in DbContext.ExamSolutions
                                          join f in DbContext.Files on es.File.Id equals f.Id
                                          where es.Uid == request.Uid 
                                          select f
                                       ).SingleOrDefaultAsync();

                        var filePath = file.FilePath;
                        var fileName = file.FileName;

                        // Determine the content type based on the file extension
                        var contentType = GetContentType(fileName);
                        solution.ContentType = contentType;

                        var memory = new MemoryStream();
                        using (var stream = new FileStream(filePath, FileMode.Open))
                        {
                            await stream.CopyToAsync(memory);
                        }
                        memory.Position = 0;

                        var fileResult = memory.ToArray();
                        solution.File = fileResult;


            var isCurrentUserOwner = solution.OwnerUid == currentUser.Uid;

            return new GetExamSolutionQueryResult
            {
                    Solution = solution,
                    IsCurrentUserOwner = isCurrentUserOwner,
            };
        }

        private string GetContentType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream"; // Default to binary
            }
            return contentType;
        }
    }
}
