using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Exceptions;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Domain.Enums;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Teachers.Commands.Update
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand,UpdateTeacherCommandResult>
    {
        readonly IUsersRepository UserRepository;
        readonly ICoursesRepository CoursesRepository;
        readonly ICoreDbContext DbContext;

        public UpdateTeacherCommandHandler
        (
            IUsersRepository userRepository,
            ICoursesRepository coursesRepository,
            ICoreDbContext dbContext
        )
        {
            UserRepository = userRepository;
            CoursesRepository=coursesRepository;
            DbContext = dbContext;

        }

        public async Task<UpdateTeacherCommandResult> Handle(UpdateTeacherCommand command, CancellationToken cancellationToken)
        {
            var user = await UserRepository.GetByUidAsync(command.UserUid, cancellationToken);

            if (user == null)
            {
                throw new NotFoundException();
            }

            var source = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Gender = command.Gender,

            };

            user.UpdateLecturer(source);
        
            

            if(command.Courses!=null)
            {
                var updatedCoursesUids = command.Courses.Select(x => x.Uid).ToList();

                var currentCourses = await CoursesRepository.GetQuery().Where(x => x.Lecturer.Uid == command.UserUid).ToListAsync();
                var currentCoursesUid = currentCourses.Select(x => x.Uid).ToList();
                var removeTeacherFromCourses = currentCourses.Where(x => !updatedCoursesUids.Contains(x.Uid)).ToList();
                var addCoursesForTeacherUids = updatedCoursesUids.Where(x => !currentCoursesUid.Contains(x)).ToList();
                foreach (var course in removeTeacherFromCourses)
                {
                    course.Lecturer = null;
                    CoursesRepository.Update(course);
                }
                foreach (var courseUid in addCoursesForTeacherUids)
                {
                    var course = await CoursesRepository.GetQuery().Where(x => x.Uid == courseUid).SingleOrDefaultAsync();
                    course.Lecturer = user;
                    CoursesRepository.Update(course);
                }
            }          
            await DbContext.SaveChangesAsync(cancellationToken);

            return new UpdateTeacherCommandResult { Uid = user.Uid };
        }
    }
}
