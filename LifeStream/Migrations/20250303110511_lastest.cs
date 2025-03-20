using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LifeStream.Migrations
{
    /// <inheritdoc />
    public partial class lastest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "DoctorsUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e476a5e-db04-4da8-99d8-453197f44c3e", null, "Receptionist", "RECEPTIONIST" },
                    { "1a0e9c2e-d331-4182-a00d-13496fa77c39", null, "Admin", "ADMIN" },
                    { "4ec49657-b8f4-4c62-a309-4983afc4cf71", null, "Patient", "PATIENT" },
                    { "c3f14613-e0a9-4e28-9cd6-834087a8a5bf", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DoctorsUserId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b7987312-c697-4889-900c-21bebf3962fd", 0, "268d832a-950b-4d54-aa97-e8e14b758204", null, "admin@lifestream.com", true, "System", "Admin", false, null, "ADMIN@LIFESTREAM.COM", "ADMIN@LIFESTREAM.COM", "AQAAAAIAAYagAAAAEDhc5iIZigkbOBbqU7v/dhIkcz/FyAKouTbBpzEKaCeo4x4f3gzyjMHUs5bxKysQcw==", null, false, 0, "0d21149d-d33c-4eef-84e2-e7c4e3aac87b", false, "admin@lifestream.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1a0e9c2e-d331-4182-a00d-13496fa77c39", "b7987312-c697-4889-900c-21bebf3962fd" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DoctorsUserId",
                table: "AspNetUsers",
                column: "DoctorsUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Doctors_DoctorsUserId",
                table: "AspNetUsers",
                column: "DoctorsUserId",
                principalTable: "Doctors",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Doctors_DoctorsUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DoctorsUserId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e476a5e-db04-4da8-99d8-453197f44c3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ec49657-b8f4-4c62-a309-4983afc4cf71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3f14613-e0a9-4e28-9cd6-834087a8a5bf");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a0e9c2e-d331-4182-a00d-13496fa77c39", "b7987312-c697-4889-900c-21bebf3962fd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a0e9c2e-d331-4182-a00d-13496fa77c39");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7987312-c697-4889-900c-21bebf3962fd");

            migrationBuilder.DropColumn(
                name: "DoctorsUserId",
                table: "AspNetUsers");

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
        }
    }
}
