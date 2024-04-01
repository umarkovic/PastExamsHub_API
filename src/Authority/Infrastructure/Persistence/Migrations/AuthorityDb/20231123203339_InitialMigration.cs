using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PastExamsHub.Authority.Infrastructure.Persistence.Migrations.AuthorityDb
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Client");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admin", "9bb95fa7-af55-4c0f-b140-3f5d4ca2864b" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bb95fa7-af55-4c0f-b140-3f5d4ca2864b");

            migrationBuilder.DropColumn(
                name: "CreatedByUserUid",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedDateTimeUtc",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedByUserUid",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedDateTimeUtc",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastModifiedByUserUid",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTimeUtc",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "c48f58f8-40e8-4a82-ac7a-d8dfdb55aae4");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Student", "9b591809-ccba-437b-9556-475dc3f63e70", "Student", "STUDENT" },
                    { "Teacher", "804e97b3-2e20-4e4d-8408-de0e51f0e3e4", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "61e79b02-319f-4832-902c-57674423997b", 0, "f6033ea5-24d6-48de-8c20-aff998be76eb", "administrator@localhost", true, "Administrator", "System", false, null, "ADMINISTRATOR@LOCALHOST", "ADMINISTRATOR@LOCALHOST", "AQAAAAEAACcQAAAAEELm4ge9uIyX8vHt3Tmon4JDORii+SgsDw1n/0R2Sq3pTxCu5Mxq58rGicX7E2tFnQ==", "0", false, 1, "56b537b1-9e16-4a0b-a090-0c7f4149484b", false, "administrator@localhost" },
                    { "4b1b3e4c-0b63-4429-a9b1-66f2e588d72d", 0, "7d8f1a06-6d11-452e-9919-4f92ad0547c2", "umarkovic864@gmail.com", true, "Uros", "Markovic", false, null, "UMARKOVIC864@GMAIL.COM", "UMARKOVIC864@GMAIL.COM", "AQAAAAEAACcQAAAAEMD8C4M2eyo3HU05poC78I3Ch+hZzNzh7VdPZdsQ2SJhz1xR060m86dVf1th1OSpfw==", "0", false, 2, "c1ed12a3-defb-4406-b9a5-04a97b7345d2", false, "umarkovic864@gmail.com" },
                    { "99f650bd-8041-488f-a9b9-4b62da5d5983", 0, "5423feab-c18e-4d53-b270-efe83002310b", "valenejkovic@gmail.com", true, "Valentina", "Nejkovic", false, null, "VALENEJKOVIC@GMAIL.COM", "VALENEJKOVIC@GMAIL.COM", "AQAAAAEAACcQAAAAEAW/W0k+kI8gCfkB2OrovZhrvMaX2RhMgoRxDeSPKJFtuYGwUcuI0tq1o/ObBLp0xA==", "0", false, 3, "588c4d69-d1f1-4f87-b979-ee3b37ffb526", false, "valenejkovic@gmail.com" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "61e79b02-319f-4832-902c-57674423997b");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "61e79b02-319f-4832-902c-57674423997b");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "61e79b02-319f-4832-902c-57674423997b");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 4, "name", "umarkovic864@gmail.com", "4b1b3e4c-0b63-4429-a9b1-66f2e588d72d" },
                    { 5, "email", "umarkovic864@gmail.com", "4b1b3e4c-0b63-4429-a9b1-66f2e588d72d" },
                    { 6, "email_verified", "True", "4b1b3e4c-0b63-4429-a9b1-66f2e588d72d" },
                    { 7, "name", "valenejkovic@gmail.com", "99f650bd-8041-488f-a9b9-4b62da5d5983" },
                    { 8, "email", "valenejkovic@gmail.com", "99f650bd-8041-488f-a9b9-4b62da5d5983" },
                    { 9, "email_verified", "True", "99f650bd-8041-488f-a9b9-4b62da5d5983" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "Admin", "61e79b02-319f-4832-902c-57674423997b" },
                    { "Student", "4b1b3e4c-0b63-4429-a9b1-66f2e588d72d" },
                    { "Teacher", "99f650bd-8041-488f-a9b9-4b62da5d5983" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Student", "4b1b3e4c-0b63-4429-a9b1-66f2e588d72d" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admin", "61e79b02-319f-4832-902c-57674423997b" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Teacher", "99f650bd-8041-488f-a9b9-4b62da5d5983" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Student");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Teacher");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b1b3e4c-0b63-4429-a9b1-66f2e588d72d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61e79b02-319f-4832-902c-57674423997b");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99f650bd-8041-488f-a9b9-4b62da5d5983");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserUid",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTimeUtc",
                schema: "Identity",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedByUserUid",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateTimeUtc",
                schema: "Identity",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByUserUid",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTimeUtc",
                schema: "Identity",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "Identity",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "866c42e1-4d3b-4b2d-b57e-26dfaa5b8f60");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "Client", "79fb752e-f94a-4f94-ae0e-dac7c976aa3f", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedByUserUid", "CreatedDateTimeUtc", "DeletedByUserUid", "DeletedDateTimeUtc", "Email", "EmailConfirmed", "FirstName", "LastModifiedByUserUid", "LastModifiedDateTimeUtc", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9bb95fa7-af55-4c0f-b140-3f5d4ca2864b", 0, "eb7a0828-0e11-41c5-8620-49ab5bce53b1", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "administrator@localhost", true, "Administrator", null, null, "System", false, null, "ADMINISTRATOR@LOCALHOST", "ADMINISTRATOR@LOCALHOST", "AQAAAAEAACcQAAAAEBsUhFYt/QseTGLL6qEVHSTW+e/gYT3ilCxtEtet5+MwaC9rDDfOWDCsa1tatw6WOA==", "0", false, 1, "6c6e7f88-6772-4745-b8f7-108ee25b9821", 1, false, "administrator@localhost" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "9bb95fa7-af55-4c0f-b140-3f5d4ca2864b");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "9bb95fa7-af55-4c0f-b140-3f5d4ca2864b");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "9bb95fa7-af55-4c0f-b140-3f5d4ca2864b");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "Admin", "9bb95fa7-af55-4c0f-b140-3f5d4ca2864b" });
        }
    }
}
