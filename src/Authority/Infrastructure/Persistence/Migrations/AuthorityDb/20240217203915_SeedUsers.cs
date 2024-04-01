using Microsoft.EntityFrameworkCore.Migrations;

namespace PastExamsHub.Authority.Infrastructure.Persistence.Migrations.AuthorityDb
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "9832004f-f63a-4712-998e-92f42b856685");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Student",
                column: "ConcurrencyStamp",
                value: "1f843d13-72ad-410c-aa21-fbac7982cb8d");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Teacher",
                column: "ConcurrencyStamp",
                value: "cb373121-ae1d-4693-a72f-6eac390ea985");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "studentDanilo", 0, "4d8a096c-c8b3-4ea2-8984-e9d687205d26", "studentDanilo@localhost", true, "Danilo", "Markovic", false, null, "STUDENTDANILO@LOCALHOST", "STUDENTDANILO@LOCALHOST", "AQAAAAEAACcQAAAAEHIN6vLQV+bvbfUpNel5aQ64uKl8IinL8bNMgX5NsMjeNnABYEVt91VX/RFjcBkkuw==", "0", false, 2, "947f8e2f-436b-4b18-941c-b934d940ce92", false, "studentDanilo@localhost" },
                    { "studentMilan", 0, "3a5ceb35-dbc0-4fd0-8017-9b0e4256f6c5", "studentMilan@localhost", true, "Milan", "Stojanovic", false, null, "STUDENTMILAN@LOCALHOST", "STUDENTMILAN@LOCALHOST", "AQAAAAEAACcQAAAAECEteZtXMhI2+UOwNdXeLai7WOtfn7M/nkOCdNxBHzQMpHlpoZdsyBLZ3rAnFO/r0g==", "0", false, 2, "69fd41e8-4e79-4b42-af5d-e36ce4b3ce3e", false, "studentMilan@localhost" },
                    { "studentSara", 0, "c4471e21-7bdd-4a8b-97c5-1be446efacb5", "studentSara@localhost", true, "Sara", "Stojanovic", false, null, "STUDENTSARA@LOCALHOST", "STUDENTSARA@LOCALHOST", "AQAAAAEAACcQAAAAEC6RZc0wpNhyKRQuB+RKr9BiFnA3omJLnqa/nAIU26XOBTLEuYWy9rjb1C9mAz9FUg==", "0", false, 2, "694b31a3-e99f-445b-a276-ecbb7593cab3", false, "studentSara@localhost" },
                    { "studentAndrija", 0, "6e3da480-f7e1-40f8-a357-6437a8f9840d", "studentAndrija@localhost", true, "Andrija", "Radosavljevic", false, null, "STUDENTANDRIJA@LOCALHOST", "STUDENTANDRIJA@LOCALHOST", "AQAAAAEAACcQAAAAEI9VStB9ahebg+9SCCRBnOUcRuEEHKNKg2Zfb92Q1i44I96SOJu0GRxxF83rvb7bQg==", "0", false, 2, "87eb7011-fc37-4c4c-b6d1-934755b1471c", false, "studentAndrija@localhost" },
                    { "studentVladimir", 0, "9b41bc91-6bff-4e15-b77b-8197b311623f", "studentVladimir@localhost", true, "Vladimir", "Milosevic", false, null, "STUDENTVLADIMIR@LOCALHOST", "STUDENTVLADIMIR@LOCALHOST", "AQAAAAEAACcQAAAAEK6Fb7Unf1qI0HZkjOEng4+mmmN2SVVB/rIyu20NJMGOJiWq0GhNQkZG1l51PjT6BQ==", "0", false, 2, "18d40506-9ad1-46b9-9203-04635940aa0d", false, "studentVladimir@localhost" },
                    { "studentPetar", 0, "f1013cec-da34-44f0-bd3e-80f56b634b73", "studentPetar@localhost", true, "Petar", "Maravic", false, null, "STUDENTPETAR@LOCALHOST", "STUDENTPETAR@LOCALHOST", "AQAAAAEAACcQAAAAEGQRBZjA6Z5NC7iMbH91YskGmdIPchPEWo6FoK0lUYNEhE6UHF2jURwkTUDxlfovkw==", "0", false, 2, "a04542cf-42ce-4dd9-89da-2c5a17f2c38b", false, "studentPetar@localhost" },
                    { "studentUros", 0, "ba0d8ac6-650a-46f7-b7c0-4c9e34b75931", "studentUros@localhost", true, "Uros", "Markovic", false, null, "STUDENTUROS@LOCALHOST", "STUDENTUROS@LOCALHOST", "AQAAAAEAACcQAAAAEALIynom62HIY2X560eHplKqrKW2mE6VcFc2GoE+fUOFrT1hgpp0uV23R7ZLaPXrbQ==", "0", false, 2, "81f26eb5-67f5-4db7-a298-84bfcf2e5d1e", false, "studentUros@localhost" },
                    { "profesorAleksandra", 0, "629369b9-29bc-4f92-81bd-b0f7e48aa6f0", "profesorAleksandra@localhost", true, "Aleksandra", "Stojnev", false, null, "PROFESORALEKSANDRA@LOCALHOST", "PROFESORALEKSANDRA@LOCALHOST", "AQAAAAEAACcQAAAAEM10kIYqY83fl5MLzEziUNHP8g4tVeTSNP85GyjmwgM6qMBg3guQc0rbDX2/P1sdSQ==", "0", false, 3, "f9d8bb0b-6d86-4afe-9519-0e4c952394de", false, "profesorAleksandra@localhost" },
                    { "profesorNatalija", 0, "a979e40c-f1bc-4a7d-a67c-27801521f1fa", "profeosrNatalija@localhost", true, "Natalija", "Stojanovic", false, null, "PROFEOSRNATALIJA@LOCALHOST", "PROFEOSRNATALIJA@LOCALHOST", "AQAAAAEAACcQAAAAEEonLYGYpCjADGnF4YrX9Tfqhqk6J+1PI99qc6C+gpPkxCnDoeiwvlTz2c5IHagnYw==", "0", false, 3, "7a4375c0-b95a-43c2-90c3-bbc3161f4afc", false, "profeosrNatalija@localhost" },
                    { "profesorIgor", 0, "a6053eed-02c4-499a-b3e3-19ce06c29ed6", "profeosrIgor@localhost", true, "Igor", "Antolovic", false, null, "PROFEOSRIGOR@LOCALHOST", "PROFEOSRIGOR@LOCALHOST", "AQAAAAEAACcQAAAAEFwHukT4riJn823wRbNXcSSKP8FgD6JD3l8Zg6TT/QkVh6YA//BijOLWY0f1EPF3rA==", "0", false, 3, "1ea0b707-85c5-417b-8c1d-69e1a194edb8", false, "profeosrIgor@localhost" },
                    { "profesorMarija", 0, "a03d5b96-7ea1-4a7e-840b-a6e51cf1ca0b", "profesorMarija@localhost", true, "Marija", "Veljanovski", false, null, "PROFESORMARIJA@LOCALHOST", "PROFESORMARIJA@LOCALHOST", "AQAAAAEAACcQAAAAEMixaWkL/7ZoDYbZZZtwNqUhbO6sSmlHx+nB0IfyyNL5Mhe2/PQmIxtTt8DjL8LISw==", "0", false, 3, "51b042c5-c124-425b-86c4-a576d3e0eada", false, "profesorMarija@localhost" },
                    { "profesorIvan", 0, "20d49f33-25d0-4231-8dbc-6b1c03eab360", "profesorIvan@localhost", true, "Ivan", "Petkovic", false, null, "PROFESORIVAN@LOCALHOST", "PROFESORIVAN@LOCALHOST", "AQAAAAEAACcQAAAAEHE5z7CGjb6MyHK/hurOQK7idDUhIXuN2PFRLxYrwV2R08vIbFC1zDuAZpwTS/lvMw==", "0", false, 3, "f87a1c7e-fa49-4a3a-80d6-1f248ba13294", false, "profesorIvan@localhost" },
                    { "profesorVladimir", 0, "b988c6a9-075f-4628-bd3c-c4d9f4596c31", "profesorVladimir@localhost", true, "Vladimir", "Simic", false, null, "PROFESORVLADIMIR@LOCALHOST", "PROFESORVLADIMIR@LOCALHOST", "AQAAAAEAACcQAAAAENBdCiq1DTRNK0n6215+SRivwh+zqujvYf49yy8V9zZEBCIfKbTB88WvZT1WhhVA2Q==", "0", false, 3, "ab0c17f1-f2cb-4089-a025-a7b21f071418", false, "profesorVladimir@localhost" },
                    { "profesorEmina", 0, "0b4b2839-4b9e-4d17-bc8f-31d2437a13f0", "profesorEmina@localhost", true, "Emina", "Milovanovic", false, null, "PROFESOREMINA@LOCALHOST", "PROFESOREMINA@LOCALHOST", "AQAAAAEAACcQAAAAECEVrUssMJkXplHTQdgwehUobuEkaC3l6hHvbRhj4jUgksUgd1t9WIKD+C6MsSqevg==", "0", false, 3, "23ed7137-e515-4d52-b6f6-e81a5a962f8c", false, "profesorEmina@localhost" },
                    { "pprofesorAleksandar", 0, "2efecea4-6538-4173-8669-04b770d0bd35", "profesorAleksandar@localhost", true, "Aleksandar", "Stanimirovic", false, null, "PROFESORALEKSANDAR@LOCALHOST", "PROFESORALEKSANDAR@LOCALHOST", "AQAAAAEAACcQAAAAELSyTewp+oml5VGiEpeesr+4beTaZQ6XYSqLo7gLCnlP9EpSurpYdJEmnfHNknse9w==", "0", false, 3, "35e8a083-1726-4084-b654-4677db42220c", false, "profesorAleksandar@localhost" },
                    { "profesorDragan", 0, "9cf2094e-d6e3-4363-9461-51de180d2667", "profesorDragan@localhost", true, "Dragan", "Stojanovic", false, null, "PROFESORDRAGAN@LOCALHOST", "PROFESORDRAGAN@LOCALHOST", "AQAAAAEAACcQAAAAEPdyFlIb56v6X3qgWsog1uanqS7gtE4EspSM/DP7GYrCGYFFpvHH5i2QcjkAdH9fJA==", "0", false, 3, "98a3009d-aa14-4bf0-8234-2cca8f6ba931", false, "profesorDragan@localhost" },
                    { "profesor", 0, "8382d19c-5690-4dc3-ae53-2dcf9f0082ac", "profesor@localhost", true, "Profesor", "Elfakovic", false, null, "PROFESOR@LOCALHOST", "PROFESOR@LOCALHOST", "AQAAAAEAACcQAAAAEJ4PzyHPQoNH9gPAnu/fNSkfZ2u36O6Cuz+lvmYut7+i+vMEoufhPoOn55+W9DDXEg==", "0", false, 3, "3000c9f1-186f-4bf6-adb3-510ccf71b507", false, "profesor@localhost" },
                    { "profesorNikola", 0, "fe8aaae8-f574-42b8-b2ad-9b68ec2305ff", "profesorNikola@localhost", true, "Nikola", "Davidovic", false, null, "PROFESORNIKOLA@LOCALHOST", "PROFESORNIKOLA@LOCALHOST", "AQAAAAEAACcQAAAAEKpggfgd/9vUrZS23C/awP49WD5+n+ZE2phNh/LBMfaHSRZofe/MtWeflI+mYR/5vA==", "0", false, 3, "3453ac85-cbf0-4135-b527-5661fd946ded", false, "profesorNikola@localhost" },
                    { "admin", 0, "91a15751-24db-433d-91dd-d393078c85e9", "administrator@localhost", true, "Administrator", "System", false, null, "ADMINISTRATOR@LOCALHOST", "ADMINISTRATOR@LOCALHOST", "AQAAAAEAACcQAAAAELtE7/Do5myDVwGqhZAxUjV4HrIc+GR9LdtEDk820oUAe1sG3Eb2uSz0YCdoxyEE+A==", "0", false, 1, "f0915c2e-f9cc-4ccb-b42e-5046ee4eb47b", false, "administrator@localhost" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "admin");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "admin");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "admin");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "profesor@localhost", "profesor" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "profesor@localhost", "profesor" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: "profesor");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "profesorDragan@localhost", "profesorDragan" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "profesorDragan@localhost", "profesorDragan" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: "profesorDragan");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 49, "name", "studentSara@localhost", "studentSara" },
                    { 33, "email_verified", "True", "profesorNatalija" },
                    { 32, "email", "profeosrNatalija@localhost", "profesorNatalija" },
                    { 31, "name", "profeosrNatalija@localhost", "profesorNatalija" },
                    { 29, "email", "profesorNikola@localhost", "profesorNikola" },
                    { 30, "email_verified", "True", "profesorNikola" },
                    { 34, "name", "profesorAleksandra@localhost", "profesorAleksandra" },
                    { 57, "email_verified", "True", "studentDanilo" },
                    { 28, "name", "profesorNikola@localhost", "profesorNikola" },
                    { 50, "email", "studentSara@localhost", "studentSara" },
                    { 35, "email", "profesorAleksandra@localhost", "profesorAleksandra" },
                    { 48, "email_verified", "True", "studentAndrija" },
                    { 37, "name", "studentUros@localhost", "studentUros" },
                    { 38, "email", "studentUros@localhost", "studentUros" },
                    { 39, "email_verified", "True", "studentUros" },
                    { 51, "email_verified", "True", "studentSara" },
                    { 40, "name", "studentPetar@localhost", "studentPetar" },
                    { 41, "email", "studentPetar@localhost", "studentPetar" },
                    { 42, "email_verified", "True", "studentPetar" },
                    { 47, "email", "studentAndrija@localhost", "studentAndrija" },
                    { 43, "name", "studentVladimir@localhost", "studentVladimir" },
                    { 44, "email", "studentVladimir@localhost", "studentVladimir" },
                    { 36, "email_verified", "True", "profesorAleksandra" },
                    { 27, "email_verified", "True", "profesorIgor" },
                    { 23, "email", "profesorMarija@localhost", "profesorMarija" },
                    { 25, "name", "profeosrIgor@localhost", "profesorIgor" },
                    { 56, "email", "studentDanilo@localhost", "studentDanilo" },
                    { 55, "name", "studentDanilo@localhost", "studentDanilo" },
                    { 10, "name", "profesorAleksandar@localhost", "pprofesorAleksandar" },
                    { 11, "email", "profesorAleksandar@localhost", "pprofesorAleksandar" },
                    { 12, "email_verified", "True", "pprofesorAleksandar" },
                    { 13, "name", "profesorEmina@localhost", "profesorEmina" },
                    { 14, "email", "profesorEmina@localhost", "profesorEmina" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 15, "email_verified", "True", "profesorEmina" },
                    { 54, "email_verified", "True", "studentMilan" },
                    { 26, "email", "profeosrIgor@localhost", "profesorIgor" },
                    { 16, "name", "profesorVladimir@localhost", "profesorVladimir" },
                    { 18, "email_verified", "True", "profesorVladimir" },
                    { 53, "email", "studentMilan@localhost", "studentMilan" },
                    { 19, "name", "profesorIvan@localhost", "profesorIvan" },
                    { 20, "email", "profesorIvan@localhost", "profesorIvan" },
                    { 21, "email_verified", "True", "profesorIvan" },
                    { 52, "name", "studentMilan@localhost", "studentMilan" },
                    { 22, "name", "profesorMarija@localhost", "profesorMarija" },
                    { 45, "email_verified", "True", "studentVladimir" },
                    { 24, "email_verified", "True", "profesorMarija" },
                    { 17, "email", "profesorVladimir@localhost", "profesorVladimir" },
                    { 46, "name", "studentAndrija@localhost", "studentAndrija" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "Student", "studentAndrija" },
                    { "Student", "studentMilan" },
                    { "Student", "studentSara" },
                    { "Admin", "admin" },
                    { "Student", "studentPetar" },
                    { "Student", "studentUros" },
                    { "Teacher", "profesorAleksandra" },
                    { "Teacher", "profesorNatalija" },
                    { "Teacher", "profesorNikola" },
                    { "Teacher", "profesorIgor" },
                    { "Teacher", "profesorMarija" },
                    { "Teacher", "profesorIvan" },
                    { "Teacher", "profesorVladimir" },
                    { "Teacher", "profesorEmina" },
                    { "Teacher", "pprofesorAleksandar" },
                    { "Teacher", "profesorDragan" },
                    { "Teacher", "profesor" },
                    { "Student", "studentVladimir" },
                    { "Student", "studentDanilo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admin", "admin" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Teacher", "pprofesorAleksandar" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Teacher", "profesor" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Teacher", "profesorAleksandra" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Teacher", "profesorDragan" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Teacher", "profesorEmina" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Teacher", "profesorIgor" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Teacher", "profesorIvan" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Teacher", "profesorMarija" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Teacher", "profesorNatalija" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Teacher", "profesorNikola" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Teacher", "profesorVladimir" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Student", "studentAndrija" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Student", "studentDanilo" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Student", "studentMilan" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Student", "studentPetar" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Student", "studentSara" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Student", "studentUros" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Student", "studentVladimir" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "pprofesorAleksandar");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "profesor");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "profesorAleksandra");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "profesorDragan");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "profesorEmina");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "profesorIgor");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "profesorIvan");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "profesorMarija");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "profesorNatalija");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "profesorNikola");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "profesorVladimir");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "studentAndrija");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "studentDanilo");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "studentMilan");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "studentPetar");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "studentSara");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "studentUros");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "studentVladimir");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "c48f58f8-40e8-4a82-ac7a-d8dfdb55aae4");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Student",
                column: "ConcurrencyStamp",
                value: "9b591809-ccba-437b-9556-475dc3f63e70");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Teacher",
                column: "ConcurrencyStamp",
                value: "804e97b3-2e20-4e4d-8408-de0e51f0e3e4");

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

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "umarkovic864@gmail.com", "4b1b3e4c-0b63-4429-a9b1-66f2e588d72d" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "umarkovic864@gmail.com", "4b1b3e4c-0b63-4429-a9b1-66f2e588d72d" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: "4b1b3e4c-0b63-4429-a9b1-66f2e588d72d");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "valenejkovic@gmail.com", "99f650bd-8041-488f-a9b9-4b62da5d5983" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "valenejkovic@gmail.com", "99f650bd-8041-488f-a9b9-4b62da5d5983" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: "99f650bd-8041-488f-a9b9-4b62da5d5983");

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
    }
}
