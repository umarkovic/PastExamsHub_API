using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Domain.Entities
{
    public class ExamSolution : DomainEntity
    {
        public Exam Exam { get; set; }
        public User User { get; set; }
        public string Comment { get; set; }
        public ExamPeriodType PeriodType { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public int? TaskNumber { get; set; }
        public File File { get; set; }
        public int GradeCount { get; set; }
        public int Grade { get; set; }
        public bool IsSoftDeleted { get; set; }

    }
}
