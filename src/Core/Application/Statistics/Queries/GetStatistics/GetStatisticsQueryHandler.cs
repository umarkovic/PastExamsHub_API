using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Domain.Enums;
using PastExamsHub.Core.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Statistics.Queries.GetStatistics
{
    public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery,GetStatisticsQueryResult>
    {
        readonly ICoursesRepository CoursesRepository;
        readonly IExamsRepository ExamsRepository;
        readonly IUsersRepository UsersRepository;
        readonly ICoreDbContext DbContext;
        public GetStatisticsQueryHandler
        (
            ICoursesRepository coursesRepository,
            IExamsRepository examsRepository,
            IUsersRepository usersRepository,
            ICoreDbContext dbContext
        )
        {
            CoursesRepository = coursesRepository;
            ExamsRepository = examsRepository;
            UsersRepository = usersRepository;
            DbContext = dbContext;
        }

        public async Task<GetStatisticsQueryResult> Handle (GetStatisticsQuery query, CancellationToken cancellationToken)
        {
            var studentsCount = UsersRepository.GetStudentsCount();
            var teachersCount = UsersRepository.GetTeachersCount();
            var examsCount = ExamsRepository.GetExamsCount();
            var coursesCount = CoursesRepository.GetCoursesCount();

            var numberOfSolutions = await (from es in DbContext.Exams select es).CountAsync();

            return new GetStatisticsQueryResult 
            {
                NumberOfStudents = studentsCount,
                NumberOfCourses = coursesCount,
                NumberOfExams = examsCount,
                NumberOfTeachers = teachersCount,
                NumberOfSolutions = numberOfSolutions
            };
        }
    }
}
