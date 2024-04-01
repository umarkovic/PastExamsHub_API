using PastExamsHub.Core.Application.Exams.Models;
using PastExamsHub.Core.Application.ExamSoultions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Queries.GetSingle
{
    public class GetExamSolutionQueryResult
    {
        public ExamSolutionFileModel Solution { get; set; }
        public bool? IsCurrentUserOwner { get; set; }
    }
}
