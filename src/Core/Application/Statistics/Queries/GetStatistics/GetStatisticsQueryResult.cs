using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Statistics.Queries.GetStatistics
{
    public class GetStatisticsQueryResult
    {
        public int? NumberOfStudents { get; set; }
        public int? NumberOfTeachers { get; set; }
        public int? NumberOfCourses { get; set; }
        public int? NumberOfExams { get; set; }
        public int? NumberOfSolutions { get; set; }
    }
}
