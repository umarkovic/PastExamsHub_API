using Microsoft.EntityFrameworkCore.Migrations;

namespace PastExamsHub.Core.Infrastructure.Persistence.Migrations.CoreDb
{
    public partial class AddsCreatedByIntoEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Exams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "ExamPeriods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CreatedById",
                table: "Exams",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ExamPeriods_CreatedById",
                table: "ExamPeriods",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatedById",
                table: "Courses",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_CreatedById",
                table: "Courses",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamPeriods_Users_CreatedById",
                table: "ExamPeriods",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Users_CreatedById",
                table: "Exams",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_CreatedById",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamPeriods_Users_CreatedById",
                table: "ExamPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Users_CreatedById",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_CreatedById",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_ExamPeriods_CreatedById",
                table: "ExamPeriods");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CreatedById",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ExamPeriods");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Courses");
        }
    }
}
