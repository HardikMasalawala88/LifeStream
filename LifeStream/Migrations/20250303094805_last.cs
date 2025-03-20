using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LifeStream.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receptionist");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e5128ff-e818-4c06-8253-6cbba861df14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1be85c47-0867-4da4-9041-e7fc5ffa8875");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6b009bb-fa42-451d-9dcc-2ed2da394de5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "154e6195-0ec3-4276-994e-855aa36fc14f", "88813d5f-2c4b-4858-92b3-6eba8c2b755d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "154e6195-0ec3-4276-994e-855aa36fc14f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88813d5f-2c4b-4858-92b3-6eba8c2b755d");

            migrationBuilder.CreateTable(
                name: "Receptionists",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionists", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Receptionists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receptionists");

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

            migrationBuilder.CreateTable(
                name: "Receptionist",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionist", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Receptionist_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e5128ff-e818-4c06-8253-6cbba861df14", null, "Receptionist", "RECEPTIONIST" },
                    { "154e6195-0ec3-4276-994e-855aa36fc14f", null, "Admin", "ADMIN" },
                    { "1be85c47-0867-4da4-9041-e7fc5ffa8875", null, "Doctor", "DOCTOR" },
                    { "f6b009bb-fa42-451d-9dcc-2ed2da394de5", null, "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "88813d5f-2c4b-4858-92b3-6eba8c2b755d", 0, "faa16585-0007-4193-8c60-ead2080819f0", "admin@lifestream.com", true, "System", "Admin", false, null, "ADMIN@LIFESTREAM.COM", "ADMIN@LIFESTREAM.COM", "AQAAAAIAAYagAAAAEF/tHz+7kAUxX/jCf28a5imF6FjIT9yn6Deo2u5HBuYtGf1IFggCdJictpKPwGnxTw==", null, false, 0, "278bec19-a7cf-43d7-85c1-239579c10c96", false, "admin@lifestream.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "154e6195-0ec3-4276-994e-855aa36fc14f", "88813d5f-2c4b-4858-92b3-6eba8c2b755d" });
        }
    }
}
