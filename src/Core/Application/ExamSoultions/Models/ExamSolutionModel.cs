using PastExamsHub.Base.Domain.Enums;
using PastExamsHub.Core.Application.ExamPeriods;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Models
{
    public class ExamSolutionModel
    {
        public string Uid { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public string OwnerUid { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public RoleType OwnerRole { get; set; }
        public FileType FileType { get; set; }
        public int? TaskNumber { get; set; }
        public string SoulutionComment { get; set; }
        public int? OwnerStudyYear { get; set; }
        public int GradeCount { get; set; }
        public int Grade { get; set; }
        public string CourseName { get; set; }
        public ExamType Type { get; set; }
        public string PeriodName { get; set; }
        public ExamPeriodType PeriodType { get; set; }
        public bool IsEditAndDeleteAllowed { get; set; }
        public bool IsAlreadyGraded { get; set; }
        public bool? IsPositiveGraded { get; set; }

    }
}
