using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Domain.Entities
{
    public class ExamPeriod : DomainEntity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ExamPeriodType PeriodType { get; set; }
        public ICollection<ExamPeriodExam> Exams { get; set; }
        public User CreatedBy { get; set; }
        public bool IsSoftDeleted { get; set; }

        public ExamPeriod(string name, DateTime startDate, DateTime endDate, ExamPeriodType periodType, User createdBy)
        {
            Uid = Guid.NewGuid().ToString();
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            PeriodType = periodType;
            Exams = new List<ExamPeriodExam>();
            IsSoftDeleted = false;
            CreatedBy = createdBy;
        }

        public ExamPeriod()
        {
            Uid = Guid.NewGuid().ToString();
            Exams = new List<ExamPeriodExam>();
            IsSoftDeleted = false;
        }


        public void UpdateFrom(ExamPeriod period)
        {
            Name = period.Name;
            StartDate = period.StartDate;
            EndDate = period.EndDate;
            PeriodType = period.PeriodType;
        }
    }
}
