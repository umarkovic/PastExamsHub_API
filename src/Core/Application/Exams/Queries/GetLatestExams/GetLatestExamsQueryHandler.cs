using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.ExamPeriods;
using PastExamsHub.Core.Application.Exams.Models;
using PastExamsHub.Core.Application.Exams.Queries.GetCollection;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Queries.GetLatestExams
{
    public class GetLatestExamsQueryHandler : IRequestHandler<GetLatestExamsQuery,GetLatestExamsQueryResult>
    {

        readonly IExamsRepository ExamsRepository;
        readonly ICoreDbContext DbContext;
        public GetLatestExamsQueryHandler
        (
            IExamsRepository examsRepository,
            ICoreDbContext dbContext
        )
        {
            ExamsRepository = examsRepository;
            DbContext = dbContext;
        }

        public async Task<GetLatestExamsQueryResult> Handle(GetLatestExamsQuery request, CancellationToken cancellationToken)
        {

            var result = await ExamsRepository
                .GetQuery()
                .OrderByDescending(x => x.ExamDate)
                .Select(e => new ExamListModel
                {
                    Uid = e.Uid,
                    CourseName = e.Course.Name,
                    CreatedDateTimeUtc = e.CreatedDateTimeUtc,
                    ExamPeriodName = e.Period.Name + ( e.Type!=ExamType.Unkwnon ? (e.Type==ExamType.PismenoUsmeni ? " - " + "Pismeno-Usmeni" : " - " + e.Type.ToString() )  :  "")

                })
                .OrderByDescending(x=>x.CreatedDateTimeUtc)
                .Take(20)
                .ToListAsync();



            return new GetLatestExamsQueryResult
            {
                LatestExams = result
            };
        }
    }
}
