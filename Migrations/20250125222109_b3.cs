using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketPurchaseAPI.Migrations
{
    public partial class b3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59f25042-2066-48a5-8c73-7f3ccbc8bb0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "749de397-3d01-4b2e-a04c-efc094973af8");

            migrationBuilder.AddColumn<int>(
                name: "PaymentCount",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4bb620d4-7918-43b4-9373-4eeb3e2c37a9", "5041756e-4f9f-48fe-9a5b-adae8e1253ce", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c37d40e3-533c-4a73-a201-e44b0bc893d7", "08fd2176-cb25-447f-8824-025fafb94067", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PaymentCount",
                table: "Tickets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59f25042-2066-48a5-8c73-7f3ccbc8bb0b", "4d158569-2ae0-4a9c-8542-f13f3456c90f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "749de397-3d01-4b2e-a04c-efc094973af8", "c3f78c53-b43e-4d38-a5c0-ebca163b6728", "Admin", "ADMIN" });
        }
    }
}
