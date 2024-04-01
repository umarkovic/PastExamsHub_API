using MediatR;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Courses.Commands.Create;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Commands.Update
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand,  UpdateCourseCommandResult>
    {
        readonly ICoreDbContext DbContext;
        readonly ICoursesRepository CoursesRepository;
        readonly IUsersRepository UsersRepository;
        public UpdateCourseCommandHandler
        (
            ICoreDbContext dbContext,
            ICoursesRepository coursesRepository,
            IUsersRepository usersRepository

        )
        {
            DbContext = dbContext;
            CoursesRepository = coursesRepository;
            UsersRepository = usersRepository;
        }
        public async Task<UpdateCourseCommandResult> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
        {
            var destination = await CoursesRepository.GetByUidAsync(command.Uid, cancellationToken);
            if(destination.Lecturer.Uid!=command.LecturerUid)
            {
                var newLecturer = await UsersRepository.GetByUidAsync(command.LecturerUid, cancellationToken);
                destination.Lecturer = newLecturer;
            }

            var source = new Course
            {
                Name = command.Name,
                CourseType = command.CourseType,
                StudyYear = command.StudyYear,
                Semester = command.Semester,
                ESPB = command.ESPB,

            };

            destination.UpdateFrom(source);

            await DbContext.SaveChangesAsync(cancellationToken);

            return new UpdateCourseCommandResult { Uid = destination.Uid };
        }
    }
}
