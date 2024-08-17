using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceiptManagment.Infrastructure.Migrations
{
    public partial class AddItemPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ItemPrice",
                table: "Item",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemPrice",
                table: "Item");
        }
    }
}
