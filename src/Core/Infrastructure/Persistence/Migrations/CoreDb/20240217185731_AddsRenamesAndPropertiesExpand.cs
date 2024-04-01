using Microsoft.EntityFrameworkCore.Migrations;

namespace PastExamsHub.Core.Infrastructure.Persistence.Migrations.CoreDb
{
    public partial class AddsRenamesAndPropertiesExpand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamSolutions_Files_DocumentId",
                table: "ExamSolutions");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "ExamSolutions",
                newName: "FileId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamSolutions_DocumentId",
                table: "ExamSolutions",
                newName: "IX_ExamSolutions_FileId");

            migrationBuilder.AddColumn<bool>(
                name: "IsSolution",
                table: "Files",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "ExamSolutions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExamSolutionGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    SolutionId = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Uid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSolutionGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamSolutionGrades_ExamSolutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "ExamSolutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamSolutionGrades_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamSolutionGrades_SolutionId",
                table: "ExamSolutionGrades",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSolutionGrades_UserId",
                table: "ExamSolutionGrades",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSolutions_Files_FileId",
                table: "ExamSolutions",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamSolutions_Files_FileId",
                table: "ExamSolutions");

            migrationBuilder.DropTable(
                name: "ExamSolutionGrades");

            migrationBuilder.DropColumn(
                name: "IsSolution",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "ExamSolutions");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "ExamSolutions",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamSolutions_FileId",
                table: "ExamSolutions",
                newName: "IX_ExamSolutions_DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSolutions_Files_DocumentId",
                table: "ExamSolutions",
                column: "DocumentId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
