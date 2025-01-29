using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketPurchaseAPI.Migrations
{
    public partial class b4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bb620d4-7918-43b4-9373-4eeb3e2c37a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c37d40e3-533c-4a73-a201-e44b0bc893d7");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "4bb620d4-7918-43b4-9373-4eeb3e2c37a9", "5041756e-4f9f-48fe-9a5b-adae8e1253ce", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c37d40e3-533c-4a73-a201-e44b0bc893d7", "08fd2176-cb25-447f-8824-025fafb94067", "User", "USER" });
        }
    }
}
