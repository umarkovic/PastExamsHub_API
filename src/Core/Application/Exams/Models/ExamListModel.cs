using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Models
{
    public class ExamListModel
    {
        public string Uid { get; set; }
        public string CourseName { get; set; }
        public string ExamPeriodName { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
    }
}
