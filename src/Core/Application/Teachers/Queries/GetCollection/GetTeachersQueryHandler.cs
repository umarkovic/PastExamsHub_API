using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Base.Domain.Enums;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Users.Models;
using PastExamsHub.Core.Application.Courses.Models;
using PastExamsHub.Core.Application.Teachers.Models;
using PastExamsHub.Core.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PastExamsHub.Core.Application.Teachers.Queries.GetCollection
{
    public class GetTeachersQueryHandler : IRequestHandler<GetTeachersQuery, GetTeachersQueryResult>
    {
        readonly ICoreDbContext DbContext;
        readonly ISearchQueryBuilder<User> QueryBuilder;
        public GetTeachersQueryHandler
        (
            ICoreDbContext dbContext,
            ISearchQueryBuilder<User> queryBuilder
        )
        {
            DbContext = dbContext;
            QueryBuilder = queryBuilder;
        }

        public async Task<GetTeachersQueryResult> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
        {

            var query =  
                (
                  from u in QueryBuilder.GetQuery(request.SearchText)
                  where u.Role == RoleType.Teacher
                  select new TeacherListModel
                  {
                      Id  = u.Id,
                      Uid = u.Uid,
                      FullName = u.FirstName + " " + u.LastName,
                      Email = u.Email
                  }
            );


            var results = await PaginationResult<TeacherListModel>.From(query, request.PageNumber, request.PageSize);

            foreach (var user in results.Items)
            {

                user.Courses = await
                    (
                        from c in DbContext.Courses
                        join u in DbContext.Users on c.Lecturer.Id equals u.Id
                        where u.Id == user.Id
                        select c.Name
                     ).ToListAsync();

                user.NumberOfCourses = user.Courses.Count();
            }






            //var ids = users.Select(x=>x.Id).ToList();


            //var coursesNames = await
            //    (
            //        from c in DbContext.Courses
            //        join u in DbContext.Users on c.Lecturer.Id equals u.Id
            //        where ids.Contains(u.Id)
            //        group c
            //        by u.Id into m_group
            //        select new
            //        {
            //            Courses = m_group.Select(x => x.Name).ToList(),
            //            UserId = m_group.Key

            //        }
            //     ).ToListAsync();


            //var finalResult = 
            //     (
            //        from u in users
            //        join cn in coursesNames
            //        on u.Id equals cn.UserId
            //         select new TeacherListModel
            //         { 
            //             Uid = u.Uid,
            //             FullName = u.FirstName + " " + u.LastName,
            //             Email = u.Email,
            //             Courses = cn.Courses
            //         }
            //      ).ToList();

            



            return new GetTeachersQueryResult 
            {
                Teachers = results.Items,
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
