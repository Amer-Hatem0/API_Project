using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketPurchaseAPI.Migrations
{
    public partial class b5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ad98ac2-3a76-462d-a161-1ce883432e1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1423dd5-ee46-4688-ab9e-610a559d14a5");

            migrationBuilder.AddColumn<string>(
                name: "BoughtBy",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "117a79ed-6e45-4c74-a105-cb5f946fca74", "8a743613-47c7-4232-b944-8b564dcfea65", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "94ff14ee-ed66-4e44-8230-bafa74ecb3d0", "8b3233d2-d9e7-4220-a86c-551a74e82cf1", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "117a79ed-6e45-4c74-a105-cb5f946fca74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94ff14ee-ed66-4e44-8230-bafa74ecb3d0");

            migrationBuilder.DropColumn(
                name: "BoughtBy",
                table: "Tickets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ad98ac2-3a76-462d-a161-1ce883432e1f", "2c853b2a-1daf-4ac8-b559-3e1e4f95e503", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1423dd5-ee46-4688-ab9e-610a559d14a5", "839a941a-b183-4a4e-89f5-a30a2b85de7c", "Admin", "ADMIN" });
        }
    }
}
