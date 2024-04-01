using MediatR;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.ExamPeriods.Command.Delete;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Commands.Delete
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand,DeleteCourseCommandResult>
    {

        readonly ICoreDbContext DbContext;
        readonly ICoursesRepository CourseRepository;
        public DeleteCourseCommandHandler
        (
            ICoursesRepository courseRepository,
            ICoreDbContext dbContext

        )
        {
            CourseRepository = courseRepository;
            DbContext = dbContext;
        }

        public async Task<DeleteCourseCommandResult> Handle(DeleteCourseCommand command, CancellationToken cancellationToken)
        {
            var course = await CourseRepository.GetByUidAsync(command.Uid, cancellationToken);


            course.IsSoftDeleted = true;
            CourseRepository.Update(course);
            await DbContext.SaveChangesAsync(cancellationToken);

            return new DeleteCourseCommandResult { Uid = course.Uid };
        }
    }
}
