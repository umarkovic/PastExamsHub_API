using PastExamsHub.Core.Application.ExamPeriods;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Models
{
    public class ExamModel
    {
        //Course
        public string CourseUid { get; set; }
        public string CourseName { get; set; }
        public CourseType CourseType { get; set; }
        public string LecturerFirstName { get; set; }
        public string LecturerLastName { get; set; }
        public int StudyYear { get; set; }
        public int ESPB { get; set; }

        //Exam
        public string ExamUid { get; set; }
        public ExamType Type { get; set; }
        public DateTime ExamDate { get; set; }
        public int NumberOfTasks { get; set; }
        public string Notes { get; set; }

        //Period

        public string PeriodUid { get; set; }
        public ExamPeriodModel ExamPeriod { get; set; }


        //File
        public FileType FileType { get; set; }
        public string ContentType { get; set; }
        public byte[] File { get; set; }


        public bool IsEditAndDeleteAllowed { get; set; }


    }
}
