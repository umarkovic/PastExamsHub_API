using MediatR;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Commands.Create
{
    public class CreateCourseCommandHandler  : IRequestHandler <CreateCourseCommand,CreateCourseCommandResult>
    {
        readonly ICoreDbContext DbContext;
        readonly ICoursesRepository CoursesRepository;
        readonly IUsersRepository UsersRepository;
        public CreateCourseCommandHandler
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
        public async Task<CreateCourseCommandResult> Handle (CreateCourseCommand command, CancellationToken cancellationToken)
        {
            var lecturer = await UsersRepository.GetByUidAsync(command.LecturerUid, cancellationToken);
            var currentUser = await UsersRepository.GetByUidAsync(command.UserUid, cancellationToken);


            Course course = new Course(command.Name, command.CourseType, command.StudyYear, command.ESPB, command.Semester, currentUser);
            course.Lecturer = lecturer;
            course.StudyType = StudyType.OsnovneAkademskeStudije; //COMPLETE: change this later

            CoursesRepository.Insert(course);

            await DbContext.SaveChangesAsync(cancellationToken);

            return new CreateCourseCommandResult { Uid = course.Uid };
        }
    }
}
