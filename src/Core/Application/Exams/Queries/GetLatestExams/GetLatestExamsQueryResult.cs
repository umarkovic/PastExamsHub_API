using PastExamsHub.Core.Application.Exams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Queries.GetLatestExams
{
    public class GetLatestExamsQueryResult
    {
        public List<ExamListModel> LatestExams { get; set; }
    }
}
