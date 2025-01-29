using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketPurchaseAPI.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a458265-e4d3-4472-a1e9-40b857cc6048");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6d03f5e-1009-4909-a43c-7adaa95ef9d0");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "0a458265-e4d3-4472-a1e9-40b857cc6048", "60e4905d-93a3-453e-b402-c87cc03081c3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6d03f5e-1009-4909-a43c-7adaa95ef9d0", "5f0b15ad-29f0-473d-8520-7b323e11782a", "Admin", "ADMIN" });
        }
    }
}
