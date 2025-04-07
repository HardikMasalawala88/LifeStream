using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LifeStream.Migrations
{
    /// <inheritdoc />
    public partial class st : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nonmedicaltaffs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1206788d-2e17-4387-b62c-8a859d07f2c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55c2a9bf-d538-438a-bfad-8e27b614b065");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e034c4a2-c014-45b9-b426-ae65fa15c3ed");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "25fc34ae-f504-4756-9b26-9527bdaf520d", "6033a350-859d-4da8-978a-4f852d6a10ec" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25fc34ae-f504-4756-9b26-9527bdaf520d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6033a350-859d-4da8-978a-4f852d6a10ec");

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOJ = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34e635c4-a3bd-4250-a667-ba86e4989b61", null, "Doctor", "DOCTOR" },
                    { "53e4491a-aa8d-43ea-b3f9-58e992ad9a80", null, "Receptionist", "RECEPTIONIST" },
                    { "63265cb2-e275-4820-9751-766a18991057", null, "Patient", "PATIENT" },
                    { "c7c1db37-342a-434f-8706-7b35c460b50f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DoctorsUserId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6ebaa794-8534-4899-b516-c07e4ba30d65", 0, "40f901a4-e9a2-48d2-b7f4-f2b1feac69c8", null, "admin@lifestream.com", true, "LifeStream", "Admin", false, null, "ADMIN@LIFESTREAM.COM", "ADMIN@LIFESTREAM.COM", "AQAAAAIAAYagAAAAEJrSyoQym060L4cyF3VJZorhQwTAK2bBf8uo/3Nwx+FKmLkknwwfnOXybfBmHdsfaw==", null, false, 0, "c8e58966-0bf5-4068-9555-b37da296e178", false, "admin@lifestream.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c7c1db37-342a-434f-8706-7b35c460b50f", "6ebaa794-8534-4899-b516-c07e4ba30d65" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34e635c4-a3bd-4250-a667-ba86e4989b61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53e4491a-aa8d-43ea-b3f9-58e992ad9a80");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63265cb2-e275-4820-9751-766a18991057");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7c1db37-342a-434f-8706-7b35c460b50f", "6ebaa794-8534-4899-b516-c07e4ba30d65" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7c1db37-342a-434f-8706-7b35c460b50f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ebaa794-8534-4899-b516-c07e4ba30d65");

            migrationBuilder.CreateTable(
                name: "nonmedicaltaffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jobtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nonmedicaltaffs", x => x.StaffId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1206788d-2e17-4387-b62c-8a859d07f2c7", null, "Receptionist", "RECEPTIONIST" },
                    { "25fc34ae-f504-4756-9b26-9527bdaf520d", null, "Admin", "ADMIN" },
                    { "55c2a9bf-d538-438a-bfad-8e27b614b065", null, "Patient", "PATIENT" },
                    { "e034c4a2-c014-45b9-b426-ae65fa15c3ed", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DoctorsUserId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6033a350-859d-4da8-978a-4f852d6a10ec", 0, "deb73ee8-acd8-43c1-ab4f-6ff007c0e963", null, "admin@lifestream.com", true, "System", "Admin", false, null, "ADMIN@LIFESTREAM.COM", "ADMIN@LIFESTREAM.COM", "AQAAAAIAAYagAAAAEEVuw61WTrlIIDXt1ju0bZ93FSPlcH8X85anrb05fHaOqWQBwx9iwVGocqDlFzkoMg==", null, false, 0, "2ba73e8f-2064-47d0-bedd-2b9e96757de7", false, "admin@lifestream.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "25fc34ae-f504-4756-9b26-9527bdaf520d", "6033a350-859d-4da8-978a-4f852d6a10ec" });
        }
    }
}
