using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class DataSementara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64588cdf-755e-4914-b93c-fb4c16044696");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d862b39c-eb5e-4db5-96ed-da2f2bc068f2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c51526fb-1060-4ae5-b670-8ebd909834a3");

            migrationBuilder.AddColumn<int>(
                name: "DataSementaraId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "dataSementaras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deskripsi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kota = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataSementaras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dataSementaras_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7343d838-efca-4a83-aecc-d92f7d302513", "fb9d7349-e5ca-4425-8d77-519b6b4d9692", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3b84a99-d2f0-4fb2-9825-c28e652e289a", "c1a39b81-1b63-4af5-af13-a854c373448e", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ebcc13c9-e7ff-4234-b5e2-2d042c2e7993", 0, null, "8e877801-87e4-4d1f-bb7d-bb58061eae1b", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEPKsTtcHgiUO2ibPijkVrbC0F4Vnp8nUODwKkdADsFirBNGq/gCTIsLGTZBox1abqg==", null, false, "d1ee8241-9fa9-4488-bbec-052cff051d9c", false, "admin@admin.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DataSementaraId",
                table: "Transactions",
                column: "DataSementaraId");

            migrationBuilder.CreateIndex(
                name: "IX_dataSementaras_CategoryId",
                table: "dataSementaras",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_dataSementaras_DataSementaraId",
                table: "Transactions",
                column: "DataSementaraId",
                principalTable: "dataSementaras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_dataSementaras_DataSementaraId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "dataSementaras");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_DataSementaraId",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7343d838-efca-4a83-aecc-d92f7d302513");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3b84a99-d2f0-4fb2-9825-c28e652e289a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebcc13c9-e7ff-4234-b5e2-2d042c2e7993");

            migrationBuilder.DropColumn(
                name: "DataSementaraId",
                table: "Transactions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d862b39c-eb5e-4db5-96ed-da2f2bc068f2", "10eb0aee-81d2-45ec-872b-276a78ae5353", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64588cdf-755e-4914-b93c-fb4c16044696", "c7063f4a-2274-45f0-8632-111afda58789", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c51526fb-1060-4ae5-b670-8ebd909834a3", 0, null, "2d52ba1f-ec5a-46c2-98b8-eb46645be1ec", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEAk40QyE2Imx0dMQyFcKgvI4lSoj7zDJ81s6OeYZIdS1YMEiV1TAiJRr9ntJTEMBig==", null, false, "97ed7a5b-198d-4bd9-8408-7aa58e084690", false, "admin@admin.com" });
        }
    }
}
