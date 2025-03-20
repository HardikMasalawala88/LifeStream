using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LifeStream.Migrations
{
    /// <inheritdoc />
    public partial class initilize1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59221a3f-fcc6-41ac-9971-03ec1742f19a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "755d5f21-217d-48c5-9024-e83fde875e12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8b19e64-362e-40fa-a183-184f16447dc2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fcd54cae-4978-43c7-ad84-16b2a8804999", "d6989e04-9043-4191-9a53-0a1d1dfc2d13" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcd54cae-4978-43c7-ad84-16b2a8804999");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6989e04-9043-4191-9a53-0a1d1dfc2d13");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Doctors");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59221a3f-fcc6-41ac-9971-03ec1742f19a", null, "Receptionist", "RECEPTIONIST" },
                    { "755d5f21-217d-48c5-9024-e83fde875e12", null, "Patient", "PATIENT" },
                    { "f8b19e64-362e-40fa-a183-184f16447dc2", null, "Doctor", "DOCTOR" },
                    { "fcd54cae-4978-43c7-ad84-16b2a8804999", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DoctorsUserId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d6989e04-9043-4191-9a53-0a1d1dfc2d13", 0, "d0d41075-65aa-4b14-b401-6ca536037bfb", null, "admin@lifestream.com", true, "System", "Admin", false, null, "ADMIN@LIFESTREAM.COM", "ADMIN@LIFESTREAM.COM", "AQAAAAIAAYagAAAAEHgRG/X//961wWIo223dRAFlPKC1gXEivgpufvAa+He8CR6FvyKafE/D1tZX1bSY+w==", null, false, 0, "d480dde9-e0e1-4a1d-99dc-e07c5c3fb934", false, "admin@lifestream.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fcd54cae-4978-43c7-ad84-16b2a8804999", "d6989e04-9043-4191-9a53-0a1d1dfc2d13" });
        }
    }
}
