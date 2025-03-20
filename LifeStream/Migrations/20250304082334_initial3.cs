using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LifeStream.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fef3775-6797-4ed4-aea1-6452bb3ab49a", null, "Doctor", "DOCTOR" },
                    { "55678e75-3935-4745-926d-cb5a6f99e7d1", null, "Patient", "PATIENT" },
                    { "81dca7de-a53a-4018-9ab9-bbbc0de9fed6", null, "Admin", "ADMIN" },
                    { "e39d0340-0af7-423f-af18-0e213c280294", null, "Receptionist", "RECEPTIONIST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DoctorsUserId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46d0de4a-f69c-4480-9685-d01f3b96d55a", 0, "deaad7ec-f571-413b-bb62-9a3da5533dcb", null, "admin@lifestream.com", true, "System", "Admin", false, null, "ADMIN@LIFESTREAM.COM", "ADMIN@LIFESTREAM.COM", "AQAAAAIAAYagAAAAEN5FNUjtHlSAHL2rNU4n1AEUVGflyFPGhR0NSt9dMiTsjqIitA/gDI02cjN/9+Th2g==", null, false, 0, "783c1042-09f5-41d4-ae66-da20bd656a00", false, "admin@lifestream.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "81dca7de-a53a-4018-9ab9-bbbc0de9fed6", "46d0de4a-f69c-4480-9685-d01f3b96d55a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fef3775-6797-4ed4-aea1-6452bb3ab49a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55678e75-3935-4745-926d-cb5a6f99e7d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e39d0340-0af7-423f-af18-0e213c280294");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "81dca7de-a53a-4018-9ab9-bbbc0de9fed6", "46d0de4a-f69c-4480-9685-d01f3b96d55a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81dca7de-a53a-4018-9ab9-bbbc0de9fed6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46d0de4a-f69c-4480-9685-d01f3b96d55a");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Patients");

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
    }
}
