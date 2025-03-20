using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LifeStream.Migrations
{
    /// <inheritdoc />
    public partial class lastest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28b42972-e056-4641-ad85-6fa51c788daa", null, "Admin", "ADMIN" },
                    { "2faf2b1b-bd18-4e65-91b0-0dc89892456d", null, "Patient", "PATIENT" },
                    { "b97e88f1-5248-4323-9429-1081c0ab0032", null, "Receptionist", "RECEPTIONIST" },
                    { "c0ae98e7-84c0-4fed-adf7-56169b3b38ce", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DoctorsUserId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5b1e5eea-6d9b-4572-8a73-777a8b797314", 0, "b26964bd-deb7-4a68-bb59-e485ef3cbb4d", null, "admin@lifestream.com", true, "System", "Admin", false, null, "ADMIN@LIFESTREAM.COM", "ADMIN@LIFESTREAM.COM", "AQAAAAIAAYagAAAAEEH9EnKd4D5i4OFcSi79Efx7lpTu96dzqNZLL/P2bSna0tl+vtrzUZFE1hdyEoeK6Q==", null, false, 0, "aefc3546-0fab-4c39-a842-c62f96e4113f", false, "admin@lifestream.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "28b42972-e056-4641-ad85-6fa51c788daa", "5b1e5eea-6d9b-4572-8a73-777a8b797314" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2faf2b1b-bd18-4e65-91b0-0dc89892456d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b97e88f1-5248-4323-9429-1081c0ab0032");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0ae98e7-84c0-4fed-adf7-56169b3b38ce");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "28b42972-e056-4641-ad85-6fa51c788daa", "5b1e5eea-6d9b-4572-8a73-777a8b797314" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28b42972-e056-4641-ad85-6fa51c788daa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b1e5eea-6d9b-4572-8a73-777a8b797314");

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
        }
    }
}
