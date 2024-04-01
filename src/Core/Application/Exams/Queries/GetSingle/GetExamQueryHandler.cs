using BitMiracle.LibTiff.Classic;
using MediatR;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.ExamPeriods;
using PastExamsHub.Core.Application.Exams.Models;
using PastExamsHub.Core.Application.Exams.Queries.GetCollection;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FileType = PastExamsHub.Core.Domain.Enums.FileType;

namespace PastExamsHub.Core.Application.Exams.Queries.GetSingle
{
    public class GetExamQueryHandler : IRequestHandler<GetExamQuery,GetExamQueryResult>
    {
        readonly IExamsRepository ExamsRepository;
        readonly ICoreDbContext DbContext;
        public GetExamQueryHandler
        (
            IExamsRepository examsRepository,
            ICoreDbContext dbContext
        )
        {
            ExamsRepository = examsRepository;
            DbContext = dbContext;
        }


        public async Task<GetExamQueryResult> Handle(GetExamQuery request, CancellationToken cancellationToken)
        {

            var result = await ExamsRepository
                .GetQuery()
                .Where(x=>x.Uid==request.Uid)
                .Select(e => new ExamModel
                {
                    ExamUid = e.Uid,
                    CourseUid = e.Course.Uid,
                    CourseName = e.Course.Name,
                    StudyYear = e.Course.StudyYear,
                    ESPB = e.Course.ESPB,
                    ExamDate = e.ExamDate,
                    CourseType = e.Course.CourseType,
                    LecturerFirstName = e.Course.Lecturer.FirstName,
                    LecturerLastName = e.Course.Lecturer.LastName,
                    Notes = e.Notes,
                    NumberOfTasks = e.NumberOfTasks,
                    Type = e.Type,
                    PeriodUid = e.Period.Uid,
                    ExamPeriod = ExamPeriodModel.From(e.Period)
                }).SingleOrDefaultAsync();


            var file = await (from e in DbContext.Exams
                                  join d in DbContext.Files on e.File.Id equals d.Id
                                  where e.Uid == request.Uid
                                  select d
                            ).SingleOrDefaultAsync();

            var filePath = file.FilePath;
            var fileName = file.FileName;

            // Determine the content type based on the file extension
            var contentType = GetContentType(fileName);
            result.ContentType = contentType;
            result.FileType = file.Type;

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            var fileResult = memory.ToArray();
            result.File = fileResult;

            //COMPLETE: Add exam soultions, comments

            return new GetExamQueryResult
            {
                Exam = result
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
