using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LifeStream.Migrations
{
    /// <inheritdoc />
    public partial class last1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14e33990-322c-4623-a927-5a6df6886c44", null, "Receptionist", "RECEPTIONIST" },
                    { "37a9ac73-63fb-4ff9-ac02-2bd46d703f7a", null, "Doctor", "DOCTOR" },
                    { "d4236af9-84a4-4b26-b795-840b5ad0a88b", null, "Patient", "PATIENT" },
                    { "f9ec3f24-fb87-44db-be67-8bfcab0e530e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e34c022-1917-4233-9a15-3fdb8c00b23d", 0, "cc675080-4aac-4d9b-a7c4-c3b1614d7b30", "admin@lifestream.com", true, "System", "Admin", false, null, "ADMIN@LIFESTREAM.COM", "ADMIN@LIFESTREAM.COM", "AQAAAAIAAYagAAAAEDS3l+b2Z42GTogv6/DXCN7b3cdiOIOTWsZTkJRFuiZ3Sp+qs+2Ec3JtwcGbYq3Hhg==", null, false, 0, "b3d3ac3b-876b-44a1-8069-c17fae1cfa5b", false, "admin@lifestream.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f9ec3f24-fb87-44db-be67-8bfcab0e530e", "8e34c022-1917-4233-9a15-3fdb8c00b23d" });

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14e33990-322c-4623-a927-5a6df6886c44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37a9ac73-63fb-4ff9-ac02-2bd46d703f7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4236af9-84a4-4b26-b795-840b5ad0a88b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f9ec3f24-fb87-44db-be67-8bfcab0e530e", "8e34c022-1917-4233-9a15-3fdb8c00b23d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9ec3f24-fb87-44db-be67-8bfcab0e530e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e34c022-1917-4233-9a15-3fdb8c00b23d");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
