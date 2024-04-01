using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Exceptions;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.XPath;
using Throw;

namespace PastExamsHub.Core.Application.Exams.Command.Create
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand,CreateExamCommandResult>
    {
        readonly ICoreDbContext DbContext;
        readonly IBaseRepository<ExamPeriod> ExamPeriodRepository;
        readonly IBaseRepository<ExamPeriodExam> ExamPeriodExamRepository;
        readonly IFilesRepository FileRepository;
        readonly IExamsRepository ExamRepository;
        readonly ICoursesRepository CoursesRepository;
        public CreateExamCommandHandler
        (
            IBaseRepository<ExamPeriod> examPeriodRepository,
            IBaseRepository<ExamPeriodExam> examPeriodExamRepository,
            IFilesRepository fileRepository,
            IExamsRepository examRepository,
            ICoursesRepository coursesRepository,
            ICoreDbContext dbContext

        )
        {
            ExamPeriodRepository = examPeriodRepository;
            ExamPeriodExamRepository = examPeriodExamRepository;
            FileRepository = fileRepository;
            ExamRepository = examRepository;
            CoursesRepository = coursesRepository;
            DbContext = dbContext;
        }
        public async Task<CreateExamCommandResult> Handle ( CreateExamCommand command, CancellationToken cancellationToken)
        {
            command.PeriodUid.ThrowIfNull();
            command.CourseUid.ThrowIfNull();

            var currentUser = await (from u in DbContext.Users where u.Uid == command.UserUid select u).FirstOrDefaultAsync();

            var validationFailures = new List<ValidationFailure>();

            var examPeriod = await ExamPeriodRepository
                .GetQuery()
                .Include(x=>x.Exams)
                .ThenInclude(x=>x.Exam)
                .ThenInclude(x=>x.Course)
                .Where(x=>x.Uid==command.PeriodUid)
                .SingleOrDefaultAsync();

            if (examPeriod==null)
            {
                validationFailures.Add(new ValidationFailure("Uid", "Exam period not found"));
                var validationResult = new ValidationResult(validationFailures);
                throw new ValidationException(validationResult.Errors);
            }

            var existingExxamCourseName = await(
                from ep in DbContext.ExamPeriods
                join e in DbContext.Exams on ep.Id equals e.Period.Id
                join c in DbContext.Courses on e.Course.Id equals c.Id
                where ep.Uid == command.PeriodUid && c.Uid == command.CourseUid
                select c.Name
                        ).SingleOrDefaultAsync(cancellationToken);


            #region Validations


            if (!string.IsNullOrEmpty(existingExxamCourseName))
            {
                validationFailures.Add(new ValidationFailure("Uid", "Exam with course: " + existingExxamCourseName + " already exist in "+examPeriod.Name +" period." ));
            }

            if (command.ExamDate <= examPeriod?.StartDate)
            {
                validationFailures.Add(new ValidationFailure("ExamDate", "Exam date must be greather than period start date : " + examPeriod.StartDate+"."));
            }

            if (command.ExamDate >= examPeriod?.EndDate)
            {
                validationFailures.Add(new ValidationFailure("ExamDate", "Exam date must be less than period end date : " + examPeriod.EndDate+".")); ;
            }


            if (validationFailures.Any())
            {
                var validationResult = new ValidationResult(validationFailures);
                throw new ValidationException(validationResult.Errors);
            }
            #endregion Validations


            var examFile = new Domain.Entities.File();

            try
            {
                var file = command.File;

                string imageFolder = Path.Combine("..", "Infrastructure", "Resources", "Images");
                string documentFolder = Path.Combine("..", "Infrastructure", "Resources", "Documents");


                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

                var imageExtensions = new List<string> { ".png", ".jpg" , ".jpeg"};
                var documentExtensions = new List<string> { ".pdf", ".docx", ".txt" };

                string folderName = imageExtensions.Contains(extension) ? imageFolder :
                                        documentExtensions.Contains(extension) ? documentFolder :
                                        throw new NotSupportedException("Unsupported file type.");

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }


                    
                    examFile.FileName = fileName;
                    examFile.FilePath = dbPath;
                    examFile.Type = imageExtensions.Contains(extension) ? FileType.Image : FileType.Document;

                    FileRepository.Insert(examFile);
                        
                    
                }
 
                else
                {
                    validationFailures.Add(new ValidationFailure("FileUpload", "No files selected ( File length = 0)"));
                    var validationResult = new ValidationResult(validationFailures);
                    throw new ValidationException(validationResult.Errors);
                }
            }
            catch (Exception ex)
            {
                validationFailures.Add(new ValidationFailure("FileUpload", "Something went wrong from file upload"));
                var validationResult = new ValidationResult(validationFailures);
                throw new ValidationException(validationResult.Errors);
            }

            var course = await CoursesRepository.GetByUidAsync(command.CourseUid, cancellationToken);
            var exam = new Exam(course, examPeriod, examFile, command.Type, command.ExamDate, command.NumberOfTasks, command.Notes, currentUser);
            ExamRepository.Insert(exam);

            var examPeriodExam  = new ExamPeriodExam(examPeriod, exam);
            examPeriod.Exams.Add(examPeriodExam);

            ExamPeriodRepository.Update(examPeriod);
            await DbContext.SaveChangesAsync(cancellationToken);


            return new CreateExamCommandResult { Uid = exam.Uid};
        }
    }
}
