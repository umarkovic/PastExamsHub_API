using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Courses.Models;
using PastExamsHub.Core.Application.Courses.Queries.GetCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Queries.GetSingle
{
    public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, GetCourseQueryResult>
    {
        readonly ICoreDbContext DbContext;
        readonly ICoursesRepository CoursesRepository;
        public GetCourseQueryHandler
        (
            ICoreDbContext dbContext,
            ICoursesRepository coursesRepository
            
        )
        {
            DbContext = dbContext;
            CoursesRepository = coursesRepository;
        }

        public async Task<GetCourseQueryResult> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await (from u in DbContext.Users where u.Uid == request.UserUid select u).FirstOrDefaultAsync();

            var result = await CoursesRepository.
                GetQuery()
                .Where(x => x.Uid == request.Uid)
                .Select(c => new CourseModel
                {
                    Uid = c.Uid,
                    Name = c.Name,
                    StudyYear = c.StudyYear,
                    ESPB = c.ESPB,
                    LecturerFirstName = c.Lecturer.FirstName,
                    LecturerLastName = c.Lecturer.LastName,
                    CourseType = c.CourseType,
                    Semester = c.Semester,
                    LecturerUid = c.Lecturer.Uid,
                    IsEditAndDeleteAllowed = c.CreatedBy.Uid == currentUser.Uid
                })
                .SingleOrDefaultAsync(cancellationToken);

            return new GetCourseQueryResult { Course = result };
        }
    }
}
