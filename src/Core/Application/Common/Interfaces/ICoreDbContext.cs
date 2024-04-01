using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;

namespace PastExamsHub.Core.Application.Common.Interfaces
{
    public interface ICoreDbContext : IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Exam> Exams { get; set; }
        DbSet<ExamPeriod> ExamPeriods { get; set; }
        DbSet<ExamPeriodExam> ExamPeriodExam { get; set; }
        DbSet<ExamSolution> ExamSolutions { get; set; }
        DbSet<ExamSolutionGrade> ExamSolutionGrades { get; set; }
        DbSet<File> Files { get; set; }
        
        
    }
}
