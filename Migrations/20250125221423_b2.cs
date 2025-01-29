using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketPurchaseAPI.Migrations
{
    public partial class b2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "354f9397-1110-452c-a1b2-ffee4a0c8b8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "804701f4-e3c7-4f25-9629-d739118e995d");

            migrationBuilder.DropColumn(
                name: "TicketSold",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "TicketSold",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "354f9397-1110-452c-a1b2-ffee4a0c8b8c", "d503c9dd-6690-4888-a14c-aadd55eb2f5c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "804701f4-e3c7-4f25-9629-d739118e995d", "95f8c4f6-ec6e-4b07-bf15-2c87dcd3305f", "Admin", "ADMIN" });
        }
    }
}
