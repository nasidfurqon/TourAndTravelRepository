using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class DeleteContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bce7bb00-2e01-4535-bef2-8a4da1d96ce4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf43bd7f-5638-41ee-aa90-2abc65be829c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b2907be-79c3-41a3-8759-ee45a8cf54ba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e68144ee-f1d2-49a9-8823-5347beb38e19", "e5bac354-6c79-4329-9c60-1cae40028cc5", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e989089d-c7ef-4ed8-a919-79543b7f1190", "783c0e52-8272-4901-ad3a-eaf11a506848", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9b2309fe-9ed3-46de-bd44-4fe3e300ba2c", 0, null, "458e1561-77ab-4917-8ba4-da4ce445b587", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAELGn8nk2fM8o7lkc30Ojg3c5Q4GSTuAVnTdmLWtqF6DTKN8uHfm6aF5h5S2ioMp1Aw==", null, false, "f73d4207-86d8-4a39-9d79-3bb7185d8b33", false, "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e68144ee-f1d2-49a9-8823-5347beb38e19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e989089d-c7ef-4ed8-a919-79543b7f1190");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b2309fe-9ed3-46de-bd44-4fe3e300ba2c");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumbePhone = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bce7bb00-2e01-4535-bef2-8a4da1d96ce4", "c3874857-9a69-454a-9bfd-32e8ffb328b1", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf43bd7f-5638-41ee-aa90-2abc65be829c", "a7723d84-8823-4aa6-831a-89e966314958", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3b2907be-79c3-41a3-8759-ee45a8cf54ba", 0, null, "35ba1cfa-f3f0-451e-b789-96be349a6fec", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEPzwdvVpZ7Q/yZiXMWxN48wjEktAN4OmOcADVtl3n4ysnUEOsZZOJL2ShEmWLxYahA==", null, false, "9b36369d-6b5b-482a-9942-256909801421", false, "admin@admin.com" });
        }
    }
}
