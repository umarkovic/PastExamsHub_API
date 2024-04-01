using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Domain.Entities
{
    public class ExamPeriodExam : DomainEntity
    {
        public ExamPeriod ExamPeriod { get; set; }
        public Exam Exam { get; set; }
        public ExamPeriodExam()
        {
            Uid = Guid.NewGuid().ToString();
        }

        public ExamPeriodExam(ExamPeriod examPeriod, Exam exam)
        {
            Uid = Guid.NewGuid().ToString();
            ExamPeriod = examPeriod;
            Exam = exam;
        }
    }
}
