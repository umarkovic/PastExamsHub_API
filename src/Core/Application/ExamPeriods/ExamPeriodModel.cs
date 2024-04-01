using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods
{
    public class ExamPeriodModel
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public ExamPeriodType PeriodType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PeriodDayDuration { get; set; }
        public bool IsEditAndDeleteAllowed { get; set; }
        public ExamPeriodModel()
        {
            
        }

        public static ExamPeriodModel From (ExamPeriod period )
        {
            if (period == null)
                return null;

            var periodModel =  new ExamPeriodModel()
            {
                EndDate = period.EndDate,
                PeriodDayDuration = period.EndDate.DayOfYear - period.StartDate.DayOfYear,
                PeriodType = period.PeriodType,
                StartDate = period.StartDate,
                Name = period.Name,
                Uid = period.Uid
            };

            return periodModel;

        }
    }
}
