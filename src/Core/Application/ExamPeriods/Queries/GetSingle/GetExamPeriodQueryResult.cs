using PastExamsHub.Core.Application.Exams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Queries.GetSingle
{
    public class GetExamPeriodQueryResult
    {
        public ExamPeriodModel ExamPeriod { get; set; }
        public List<ExamModel> Exams { get; set; }
    }
}
