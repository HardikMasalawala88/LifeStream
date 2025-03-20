using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LifeStream.Migrations
{
    /// <inheritdoc />
    public partial class initiall4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "nonmedicaltaffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jobtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nonmedicaltaffs");

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
    }
}
