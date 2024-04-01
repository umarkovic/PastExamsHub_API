using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PastExamsHub.Core.Infrastructure.Persistence.Migrations.CoreDb
{
    public partial class InitialMigraiton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodType = table.Column<int>(type: "int", nullable: false),
                    IsSoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Uid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: true),
                    StudyYear = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseType = table.Column<int>(type: "int", nullable: false),
                    StudyType = table.Column<int>(type: "int", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: true),
                    StudyYear = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    ESPB = table.Column<int>(type: "int", nullable: false),
                    IsSoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Uid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Users_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    PeriodId = table.Column<int>(type: "int", nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfTasks = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Uid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exams_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exams_ExamPeriods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "ExamPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamPeriodExam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamPeriodId = table.Column<int>(type: "int", nullable: true),
                    ExamId = table.Column<int>(type: "int", nullable: true),
                    Uid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamPeriodExam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamPeriodExam_ExamPeriods_ExamPeriodId",
                        column: x => x.ExamPeriodId,
                        principalTable: "ExamPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamPeriodExam_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamSolutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodType = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskNumber = table.Column<int>(type: "int", nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    GradeCount = table.Column<int>(type: "int", nullable: false),
                    IsSoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Uid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSolutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamSolutions_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamSolutions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamSolutions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "FullName", "Gender", "Index", "LastName", "Role", "StudyYear", "Uid" },
                values: new object[] { 1, "administrator@localhostt", "Administrator", null, 1, null, "System", 1, null, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "FullName", "Gender", "Index", "LastName", "Role", "StudyYear", "Uid" },
                values: new object[] { 2, "profesor@localhost", "Profesor", null, 1, null, "Elfakovic", 3, null, "profesor" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseType", "ESPB", "IsSoftDeleted", "LecturerId", "Name", "Semester", "StudyType", "StudyYear", "Uid" },
                values: new object[,]
                {
                    { 1, 1, 6, false, 2, "Algoritmi i programiranje", 2, 1, 1, "aip" },
                    { 22, 2, 6, false, 2, "Teorija grafova", 1, 1, 2, "tg" },
                    { 23, 2, 6, false, 2, "Verovatnoca i statistika", 2, 1, 2, "statistika" },
                    { 24, 1, 6, false, 2, "Distribuirani Sistemi", 1, 1, 3, "ds" },
                    { 25, 1, 6, false, 2, "Engleski jezik 1", 1, 1, 3, "eng1" },
                    { 26, 1, 6, false, 2, "Engleski jezik 2", 1, 1, 3, "eng2" },
                    { 27, 1, 6, false, 2, "Informacioni sistemi", 1, 1, 3, "is" },
                    { 28, 1, 6, false, 2, "Mikroracunarski sistemi", 2, 1, 3, "mkis" },
                    { 21, 1, 6, false, 2, "Racunarski Sistemi", 1, 1, 2, "rs" },
                    { 29, 1, 6, false, 2, "Objektno orijentisano projektovanje", 1, 1, 3, "ooproj" },
                    { 31, 1, 6, false, 2, "Sistemi baza podataka", 2, 1, 3, "sitemibaza" },
                    { 32, 1, 6, false, 2, "Softversko inzenjerstvo", 2, 1, 3, "softversko" },
                    { 33, 1, 6, false, 2, "Web programiranje", 2, 1, 3, "webprog" },
                    { 34, 1, 6, false, 2, "Napredne baze podataka", 2, 1, 4, "npbaze" },
                    { 35, 1, 6, false, 2, "Paralelni sistemi", 1, 1, 4, "ps" },
                    { 36, 1, 6, false, 2, "Programski prevodioci", 1, 1, 4, "pprevodioci" },
                    { 37, 1, 6, false, 2, "Racunarska grafika", 2, 1, 4, "grafika" },
                    { 30, 1, 6, false, 2, "Racunarske mreze", 1, 1, 3, "mreze" },
                    { 38, 1, 6, false, 2, "Vestacka inteligencija", 2, 1, 4, "vestacka" },
                    { 20, 1, 6, false, 2, "Strukture Podataka", 2, 1, 2, "strukture" },
                    { 18, 1, 6, false, 2, "Objektno orijentisano programiranje", 2, 1, 2, "oop" },
                    { 2, 1, 6, false, 2, "Elektronske komponente", 1, 1, 1, "elkomp" },
                    { 3, 1, 6, false, 2, "Fizika", 1, 1, 1, "fizika" },
                    { 4, 1, 3, false, 2, "Lab praktikum - Fizika", 1, 1, 1, "labfizika" },
                    { 5, 1, 6, false, 2, "Matematika 1", 1, 1, 1, "mat1" },
                    { 6, 1, 5, false, 2, "Matematika 2", 2, 1, 1, "mat2" },
                    { 7, 1, 6, false, 2, "Osnovi elektrotehnike 1", 1, 1, 1, "oe1" },
                    { 8, 1, 6, false, 2, "Osnovi elektrotehnike 2", 2, 1, 1, "oe2" },
                    { 19, 1, 6, false, 2, "Programski jezici", 1, 1, 2, "pj" },
                    { 9, 1, 3, false, 2, "Uvod u elektroniku", 2, 1, 1, "uue" },
                    { 11, 1, 3, false, 2, "Uvod u racunarstvo", 2, 1, 1, "uur" },
                    { 12, 1, 6, false, 2, "Arhitektura i organizacija racunara", 1, 1, 2, "aor" },
                    { 13, 1, 6, false, 2, "Baze Podataka", 1, 1, 2, "baze" },
                    { 14, 1, 5, false, 2, "Digitalna elektronika", 1, 1, 2, "digitalelekt" },
                    { 15, 1, 5, false, 2, "Diskretna matematika", 1, 1, 2, "diskrmat" },
                    { 16, 2, 5, false, 2, "Logicko projektovanje", 2, 1, 2, "logproj" },
                    { 17, 2, 6, false, 2, "Matematicki metodi u racunarstvu", 1, 1, 2, "mmur" },
                    { 10, 1, 3, false, 2, "Uvod u inzenjerstvo", 2, 1, 1, "uui" },
                    { 39, 1, 6, false, 2, "Zastita informacija", 1, 1, 4, "zastita" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LecturerId",
                table: "Courses",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamPeriodExam_ExamId",
                table: "ExamPeriodExam",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamPeriodExam_ExamPeriodId",
                table: "ExamPeriodExam",
                column: "ExamPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CourseId",
                table: "Exams",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_DocumentId",
                table: "Exams",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_PeriodId",
                table: "Exams",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSolutions_DocumentId",
                table: "ExamSolutions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSolutions_ExamId",
                table: "ExamSolutions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSolutions_UserId",
                table: "ExamSolutions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamPeriodExam");

            migrationBuilder.DropTable(
                name: "ExamSolutions");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "ExamPeriods");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
