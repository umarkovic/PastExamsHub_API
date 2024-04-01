using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Queries.GetCollection
{
    public class GetExamPeriodsQueryHandler : IRequestHandler <GetExamPeriodsQuery,GetExamPeriodsQueryResult>
    {
        readonly ICoreDbContext DbContext;
        readonly ISearchQueryBuilder<ExamPeriod> QueryBuilder;
        public GetExamPeriodsQueryHandler
        (
            ICoreDbContext dbContext,
            ISearchQueryBuilder<ExamPeriod> queryBuilder
        )
        {
            DbContext = dbContext;
            QueryBuilder = queryBuilder;
        }

        public async Task<GetExamPeriodsQueryResult> Handle(GetExamPeriodsQuery request, CancellationToken cancellationToken)
        {

            var currentUser = await (from u in DbContext.Users where u.Uid == request.UserUid select u).FirstOrDefaultAsync();

            var query  =  (
                from ep in QueryBuilder.GetQuery(request.SearchText)
                join u in DbContext.Users on ep.CreatedBy.Id equals u.Id
                orderby ep.StartDate descending
                where ep.IsSoftDeleted == false &&
                (request.Filter == null || request.Filter.PeriodType==null || ep.PeriodType == request.Filter.PeriodType)
                select new ExamPeriodModel
                {
                    Uid = ep.Uid,
                    Name = ep.Name,
                    StartDate = ep.StartDate.Date,
                    EndDate = ep.EndDate.Date,
                    PeriodDayDuration = (ep.EndDate.Date - ep.StartDate.Date).Days,
                    PeriodType = ep.PeriodType,
                    IsEditAndDeleteAllowed = u.Uid == currentUser.Uid
                }
                );

    

            var results = await PaginationResult<ExamPeriodModel>.From(query, request.PageNumber, request.PageSize);

            return new GetExamPeriodsQueryResult 
            {
                Periods = results.Items,
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
