using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Users.Models;
using PastExamsHub.Core.Application.Courses.Models;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static OneOf.Types.TrueFalseOrNull;

namespace PastExamsHub.Core.Application.Courses.Queries.GetCollection
{
    public class GetCoursesQueryHandler :  IRequestHandler<GetCoursesQuery,GetCoursesQueryResult>
    {

        readonly ICoreDbContext DbContext;
        readonly ISearchQueryBuilder<Course> QueryBuilder;
        public GetCoursesQueryHandler
        (
           ICoreDbContext dbContext,
           ISearchQueryBuilder<Course> queryBuilder
        )
        {
            DbContext = dbContext;
            QueryBuilder = queryBuilder;
        }

        public async Task<GetCoursesQueryResult> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            //COMPLETE: Add fulltext search
            if (request.StudyYear == 0)
                request.StudyYear = null;

            var currentUser = await (from u in DbContext.Users where u.Uid ==request.UserUid select u).FirstOrDefaultAsync();

            var query = (
                from c in QueryBuilder.GetQuery(request.SearchText)
                join o in DbContext.Users on c.CreatedBy.Id equals o.Id
                join u in DbContext.Users on c.Lecturer.Id equals u.Id into u_join     
                from _u in u_join.DefaultIfEmpty()
                where 
                (request.StudyYear== null || c.StudyYear == request.StudyYear) &&
                (request.Filter== null || request.Filter.TeacherUid == null ||_u.Uid == request.Filter.TeacherUid) &&
                (request.Filter == null || request.Filter.Type == CourseType.Unknown || c.CourseType == request.Filter.Type) &&
                c.IsSoftDeleted ==false
                select new CourseModel
                {
                    Uid = c.Uid,
                    Name = c.Name,
                    StudyYear =c.StudyYear,
                    ESPB = c.ESPB,
                    LecturerUid =  _u != null ? _u.Uid : null,
                    LecturerFirstName = _u != null ? _u.FirstName : "/",
                    LecturerLastName = _u != null ? _u.LastName : "/",
                    CourseType = c.CourseType,
                    StudyType = c.StudyType,
                    Semester = c.Semester,
                    IsEditAndDeleteAllowed = o.Uid == currentUser.Uid

                }
                );


            var results = await PaginationResult<CourseModel>.From(query, request.PageNumber, request.PageSize);


            return new GetCoursesQueryResult 
            { 
                Courses = results.Items,
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
