using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Domain.Entities
{
    public class ExamSolutionGrade : DomainEntity
    {
        public User User { get; set; }
        public ExamSolution Solution { get; set; }
        public int Grade { get; set; } //Can be -1 or +1

        public ExamSolutionGrade()
        {
            Uid = Guid.NewGuid().ToString();
        }
        public ExamSolutionGrade( User user, ExamSolution solution, int grade)
        {
            Uid = Guid.NewGuid().ToString();
            User = user;
            Solution = solution;
            Grade = grade;
        }
    }
}
