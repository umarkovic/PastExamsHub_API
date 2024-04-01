using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Courses.Models;
using PastExamsHub.Core.Application.ExamPeriods;
using PastExamsHub.Core.Application.Exams.Models;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Queries.GetCollection
{
    public class GetExamsQueryHandler : IRequestHandler<GetExamsQuery,GetExamsQueryResult>
    {
        readonly IExamsRepository ExamsRepository;
        readonly ICoreDbContext DbContext;
        public GetExamsQueryHandler
        (
            IExamsRepository examsRepository,
            ICoreDbContext dbContext
        )
        {
            ExamsRepository = examsRepository;
            DbContext = dbContext;
        }

        public async Task<GetExamsQueryResult> Handle (GetExamsQuery request , CancellationToken cancellationToken)
        {
            var currentUser = await (from u in DbContext.Users where u.Uid == request.UserUid select u).FirstOrDefaultAsync();
            var query = ExamsRepository
                .GetQuery()
                .OrderByDescending(x=>x.ExamDate)
                .Where(x=>x.IsSoftDeleted==false)
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
                    ExamPeriod = ExamPeriodModel.From(e.Period),
                    IsEditAndDeleteAllowed = e.CreatedBy.Uid == currentUser.Uid
                });

            query = request.CourseUid != null ? query.Where(x => x.CourseUid == request.CourseUid) : query;
            query = request.ExamPeriodUid != null ? query.Where(x => x.PeriodUid == request.ExamPeriodUid): query;


            var results = await PaginationResult<ExamModel>.From(query, request.PageNumber, request.PageSize);

            return new GetExamsQueryResult 
            {
                Exams = results.Items,
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
