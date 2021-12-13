using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShopAPIdotnet.Migrations
{
    public partial class Addedpaymenymethodtoorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "paymentMethod",
                table: "Orders",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paymentMethod",
                table: "Orders");
        }
    }
}
