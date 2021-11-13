using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class UpdateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d9e62a5-0e2e-4e09-8636-47800efc495b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f703fdbf-e1c2-4284-b487-9e5a6763a06e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76247bb6-12f6-44db-8de1-edd65ee88c30");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Transactions",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f639eb47-2ff5-473b-a32b-4cc6f73ac8bf", "0e797716-807b-4794-a395-0fe0d68e0b66", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfbc80a2-9e8d-4dc0-adb0-7c1c591d6a4f", "2001a3f9-1551-4d4c-81ad-1191cecd71ec", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a2e37327-9736-4508-be2a-7a42704d7525", 0, null, "a7eae58d-06ba-40fa-b14c-fb88498a509a", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEHQ2ane7leUn17HygIG++a3RYjhi9HdLp3IX77NiBLI8ExLs3ho8yx++2vSZiGpjaQ==", null, false, "767012f9-7c22-4a0c-8d69-e595e0b1a513", false, "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfbc80a2-9e8d-4dc0-adb0-7c1c591d6a4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f639eb47-2ff5-473b-a32b-4cc6f73ac8bf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2e37327-9736-4508-be2a-7a42704d7525");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Transactions",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f703fdbf-e1c2-4284-b487-9e5a6763a06e", "2f1a04ae-e0d0-42ab-8106-8a660a4254cb", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d9e62a5-0e2e-4e09-8636-47800efc495b", "db7af150-78f4-4d44-81a0-269da6b0fbd3", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "76247bb6-12f6-44db-8de1-edd65ee88c30", 0, null, "943746d5-1070-431b-a377-5b602b02ac0d", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEId5mzrdYkVgaMH9by837LkouXrrtf1/aomCsoZ0h//4CrN6vPny4qYit7WD3Dkh3g==", null, false, "0d8d1449-0a10-40e6-8f2b-8c547071f13c", false, "admin@admin.com" });
        }
    }
}
