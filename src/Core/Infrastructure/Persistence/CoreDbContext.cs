using PastExamsHub.Base.Infrastructure.Persistence;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using PastExamsHub.Core.Domain;
using PastExamsHub.Core.Domain.Entities;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Numerics;
using System.Text.RegularExpressions;
using PastExamsHub.Base.Domain.Enums;
using PastExamsHub.Core.Domain.Enums;
using System.Collections.Generic;
using System;

namespace PastExamsHub.Core.Infrastructure.Persistence
{
    public class CoreDbContext : ApplicationDbContext, ICoreDbContext
    {
        #region Tables

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamPeriod> ExamPeriods { get; set; }
        public DbSet<ExamPeriodExam> ExamPeriodExam { get; set; }
        public DbSet<ExamSolution> ExamSolutions { get; set; }
        public DbSet<ExamSolutionGrade> ExamSolutionGrades { get; set; }
        public DbSet<File> Files { get; set; }

        #endregion Tables
        public CoreDbContext
        (
            DbContextOptions<CoreDbContext> options,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService,
            IDateTime dateTime
        ) : base
        (
            options,
            currentUserService,
            domainEventService,
            dateTime
        )
        {
        }

        //TODO: needs better name
        public override bool OnMigrate()
        {
            return !Database.IsInMemory();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Course>()
                .HasOne(y => y.Lecturer);

            builder.Entity<ExamPeriod>()
                .HasMany(x => x.Exams);

            //builder.Entity<Asset>().HasData(AssetData);


            Seed(builder);
        }


        void Seed(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(UserData());
            builder.Entity<Course>().HasData(CourseData());






        }

        IEnumerable<object> UserData()
        {
            int i = 0;

            yield return new { Id = ++i, Uid = "admin", Email = "administrator@localhostt", FirstName = "Administrator", LastName = "System", Gender = GenderType.Musko , Role = RoleType.Admin};
            yield return new { Id = ++i, Uid = "profesor", Email = "profesor@localhost", FirstName = "Profesor", LastName = "Elfakovic", Gender = GenderType.Musko, Role = RoleType.Teacher };




        }

        IEnumerable<object> CourseData()
        {
            int i = 0;
            //1 god
            yield return new { Id = ++i, Uid = "aip", Name = "Algoritmi i programiranje", CourseType =CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 1,Semester = 2, ESPB = 6 , IsSoftDeleted = false};
            yield return new { Id = ++i, Uid = "elkomp", Name = "Elektronske komponente", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 1, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "fizika", Name = "Fizika", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 1, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "labfizika", Name = "Lab praktikum - Fizika", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 1, Semester = 1, ESPB = 3, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "mat1", Name = "Matematika 1", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 1, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "mat2", Name = "Matematika 2", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 1, Semester = 2, ESPB = 5, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "oe1", Name = "Osnovi elektrotehnike 1", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 1, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "oe2", Name = "Osnovi elektrotehnike 2", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 1, Semester = 2, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "uue", Name = "Uvod u elektroniku", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 1, Semester = 2, ESPB = 3, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "uui", Name = "Uvod u inzenjerstvo", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 1, Semester = 2, ESPB = 3, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "uur", Name = "Uvod u racunarstvo", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 1, Semester = 2, ESPB = 3, IsSoftDeleted = false };

            //2 god
            yield return new { Id = ++i, Uid = "aor", Name = "Arhitektura i organizacija racunara", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 2, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "baze", Name = "Baze Podataka", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 2, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "digitalelekt", Name = "Digitalna elektronika", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 2, Semester = 1,ESPB = 5, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "diskrmat", Name = "Diskretna matematika", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 2, Semester = 1, ESPB = 5, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "logproj", Name = "Logicko projektovanje", CourseType = CourseType.Izborni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 2, Semester = 2, ESPB = 5, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "mmur", Name = "Matematicki metodi u racunarstvu", CourseType = CourseType.Izborni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 2, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "oop", Name = "Objektno orijentisano programiranje", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 2, Semester = 2, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "pj", Name = "Programski jezici", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 2, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "strukture", Name = "Strukture Podataka", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 2, Semester = 2, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "rs", Name = "Racunarski Sistemi", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 2, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "tg", Name = "Teorija grafova", CourseType = CourseType.Izborni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 2, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "statistika", Name = "Verovatnoca i statistika", CourseType = CourseType.Izborni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 2, Semester = 2, ESPB = 6, IsSoftDeleted = false };


            //3god
            yield return new { Id = ++i, Uid = "ds", Name = "Distribuirani Sistemi", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 3, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "eng1", Name = "Engleski jezik 1", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 3, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "eng2", Name = "Engleski jezik 2", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 3, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "is", Name = "Informacioni sistemi", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 3, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "mkis", Name = "Mikroracunarski sistemi", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 3, Semester = 2, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "ooproj", Name = "Objektno orijentisano projektovanje", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 3, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "mreze", Name = "Racunarske mreze", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 3, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "sitemibaza", Name = "Sistemi baza podataka", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 3, Semester = 2, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "softversko", Name = "Softversko inzenjerstvo", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 3, Semester = 2, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "webprog", Name = "Web programiranje", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 3, Semester =2, ESPB = 6, IsSoftDeleted = false };

            //4 god

            yield return new { Id = ++i, Uid = "npbaze", Name = "Napredne baze podataka", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 4, Semester = 2, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "ps", Name = "Paralelni sistemi", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 4, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "pprevodioci", Name = "Programski prevodioci", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 4, Semester = 1, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "grafika", Name = "Racunarska grafika", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 4, Semester = 2, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "vestacka", Name = "Vestacka inteligencija", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 4, Semester =2, ESPB = 6, IsSoftDeleted = false };
            yield return new { Id = ++i, Uid = "zastita", Name = "Zastita informacija", CourseType = CourseType.Obavezni, StudyType = StudyType.OsnovneAkademskeStudije, LecturerId = 2, StudyYear = 4, Semester = 1, ESPB = 6, IsSoftDeleted = false };
        }
    }
}
