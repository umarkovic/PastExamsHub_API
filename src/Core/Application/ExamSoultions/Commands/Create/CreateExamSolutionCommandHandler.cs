using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Exceptions;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Exams.Command.Create;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Throw;

namespace PastExamsHub.Core.Application.ExamSoultions.Commands.Create
{
    public class CreateExamSolutionCommandHandler : IRequestHandler<CreateExamSolutionCommand, CreateExamSolutionCommandResult>
    {

        readonly ICoreDbContext DbContext;
        readonly IUsersRepository UsersRepository;
        readonly IExamsRepository ExamRepository;
        readonly IBaseRepository<ExamSolution> ExamSolutionRepository;
        readonly IFilesRepository FileRepository;
        public CreateExamSolutionCommandHandler
        (
            IUsersRepository usersRepository,
            IExamsRepository examRepository,
            ICoreDbContext dbContext,
            IBaseRepository<ExamSolution> examSolutionRepository,
            IFilesRepository fileRepository

        )
        {

            UsersRepository= usersRepository;
            ExamRepository = examRepository;
            DbContext = dbContext;
            ExamSolutionRepository = examSolutionRepository;
            FileRepository = fileRepository;
        }

        public async Task<CreateExamSolutionCommandResult> Handle(CreateExamSolutionCommand command, CancellationToken cancellationToken)
        {

            command.ExamUid.ThrowIfNull();
            command.UserUid.ThrowIfNull();

            var validationFailures = new List<ValidationFailure>();

            var exam = await ExamRepository.GetQuery().Where(x => x.Uid == command.ExamUid).SingleOrDefaultAsync();
            var user = await UsersRepository.GetByUidAsync(command.UserUid,cancellationToken);


            var examFile = new Domain.Entities.File();

           

            try
            {
                var file = command.File;

                string imageFolder = Path.Combine("..", "Infrastructure", "Resources", "Images");
                string documentFolder = Path.Combine("..", "Infrastructure", "Resources", "Documents");


                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

                var imageExtensions = new List<string> { ".png", ".jpg", ".jpeg" };
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
                    examFile.IsSolution = true;
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


            var examSoultion = new ExamSolution
            {
                Uid = Guid.NewGuid().ToString(),
                Exam = exam,
                User = user,
                GradeCount = 0,
                TaskNumber = command.TaskNumber,
                PeriodType = exam.Period.PeriodType,
                Comment = command.Comment,
                CreatedDateTimeUtc= DateTime.UtcNow,
                File = examFile!=null ? examFile : null,
            };


            ExamSolutionRepository.Insert(examSoultion);
            await DbContext.SaveChangesAsync(cancellationToken);


      

            return new CreateExamSolutionCommandResult { Uid = null };
        }
    }
}

