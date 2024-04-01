using Microsoft.EntityFrameworkCore.Migrations;

namespace PastExamsHub.Core.Infrastructure.Persistence.Migrations.CoreDb
{
    public partial class RenamesDocumentIntoFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Files_DocumentId",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "Exams",
                newName: "FileId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_DocumentId",
                table: "Exams",
                newName: "IX_Exams_FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Files_FileId",
                table: "Exams",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Files_FileId",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "Exams",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_FileId",
                table: "Exams",
                newName: "IX_Exams_DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Files_DocumentId",
                table: "Exams",
                column: "DocumentId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
