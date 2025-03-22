using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LifeStream.Migrations
{
    /// <inheritdoc />
    public partial class ls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b00076-6126-43da-a6dd-ea2b0c01a258");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60d64e1e-6c68-4313-a807-436c55be448b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e00191de-33bd-459d-bf4a-43d6a580a7f2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2bbe9a40-149d-44a7-8c49-aca89650ed68", "45ab807d-70d1-4bda-800e-804841186962" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bbe9a40-149d-44a7-8c49-aca89650ed68");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45ab807d-70d1-4bda-800e-804841186962");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bbe9a40-149d-44a7-8c49-aca89650ed68", null, "Admin", "ADMIN" },
                    { "38b00076-6126-43da-a6dd-ea2b0c01a258", null, "Receptionist", "RECEPTIONIST" },
                    { "60d64e1e-6c68-4313-a807-436c55be448b", null, "Patient", "PATIENT" },
                    { "e00191de-33bd-459d-bf4a-43d6a580a7f2", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DoctorsUserId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "45ab807d-70d1-4bda-800e-804841186962", 0, "a9747fcb-7576-4ece-af01-bcd8bfcdfc11", null, "admin@lifestream.com", true, "System", "Admin", false, null, "ADMIN@LIFESTREAM.COM", "ADMIN@LIFESTREAM.COM", "AQAAAAIAAYagAAAAEF8d9nkauUHf+V1sZPQ5iTTPlP6phc+Dz/kSw58FPZa8tDkD94k7sutfWr72xGbbOg==", null, false, 0, "14aaad2b-ccc0-47b5-8319-b6cae83ab034", false, "admin@lifestream.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2bbe9a40-149d-44a7-8c49-aca89650ed68", "45ab807d-70d1-4bda-800e-804841186962" });
        }
    }
}
