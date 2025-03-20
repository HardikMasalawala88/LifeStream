using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LifeStream.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ee6f289-47c0-4df2-9c4f-e840220a8d5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa0368d9-bd16-4ed3-ad27-334493c081dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2cfb46a-843b-494b-a602-7f40cfe3b00d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e93a78e8-2e23-40bb-a66b-fe158311ce59", "7832f4cd-704c-44c3-93e4-c18b6bc4fedf" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e93a78e8-2e23-40bb-a66b-fe158311ce59");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7832f4cd-704c-44c3-93e4-c18b6bc4fedf");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Receptionists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Receptionists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Receptionists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47e3dbc8-4add-416a-92f1-34df1fc27546", null, "Doctor", "DOCTOR" },
                    { "797eb1a6-5da6-4748-b65c-048c5de7fc71", null, "Receptionist", "RECEPTIONIST" },
                    { "8ae52ca1-17e8-40d4-bf73-4f43a5c0940c", null, "Admin", "ADMIN" },
                    { "9dd7e2d9-1455-4993-9e24-fa021869f3e5", null, "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f7127dfd-9327-4bc3-bb20-1a2387a7458a", 0, "85551dc3-7767-473b-a681-32793c783ba2", "admin@lifestream.com", true, "System", "Admin", false, null, "ADMIN@LIFESTREAM.COM", "ADMIN@LIFESTREAM.COM", "AQAAAAIAAYagAAAAECO8sFOYmHVc+WXE9hPjOLXcGhaGgLWlA+/jg0eVqyii7OY9EuXtAky+Y+2UfNhDAw==", null, false, 0, "36b0a4f0-913a-4241-ab97-049c00bcbd4c", false, "admin@lifestream.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8ae52ca1-17e8-40d4-bf73-4f43a5c0940c", "f7127dfd-9327-4bc3-bb20-1a2387a7458a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47e3dbc8-4add-416a-92f1-34df1fc27546");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "797eb1a6-5da6-4748-b65c-048c5de7fc71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dd7e2d9-1455-4993-9e24-fa021869f3e5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8ae52ca1-17e8-40d4-bf73-4f43a5c0940c", "f7127dfd-9327-4bc3-bb20-1a2387a7458a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ae52ca1-17e8-40d4-bf73-4f43a5c0940c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7127dfd-9327-4bc3-bb20-1a2387a7458a");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Receptionists");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Receptionists");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Receptionists");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Doctors");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ee6f289-47c0-4df2-9c4f-e840220a8d5c", null, "Patient", "PATIENT" },
                    { "aa0368d9-bd16-4ed3-ad27-334493c081dd", null, "Doctor", "DOCTOR" },
                    { "e2cfb46a-843b-494b-a602-7f40cfe3b00d", null, "Receptionist", "RECEPTIONIST" },
                    { "e93a78e8-2e23-40bb-a66b-fe158311ce59", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7832f4cd-704c-44c3-93e4-c18b6bc4fedf", 0, "ed2f9d92-1ee3-4936-8e77-7ca24aab6789", "admin@lifestream.com", true, "System", "Admin", false, null, "ADMIN@LIFESTREAM.COM", "ADMIN@LIFESTREAM.COM", "AQAAAAIAAYagAAAAEDvCZvjqfRF1D83TJPPhnWopFUKgf2TrxpF/dveqxLafkkbaqugkiw6hRuK/2SaYuQ==", null, false, 0, "60a9158b-d032-4913-919d-b823384d21e4", false, "admin@lifestream.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e93a78e8-2e23-40bb-a66b-fe158311ce59", "7832f4cd-704c-44c3-93e4-c18b6bc4fedf" });
        }
    }
}
