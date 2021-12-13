using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShopAPIdotnet.Migrations
{
    public partial class Addedicollectioproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderRowid",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderRowid",
                table: "Products",
                column: "OrderRowid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderRows_OrderRowid",
                table: "Products",
                column: "OrderRowid",
                principalTable: "OrderRows",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderRows_OrderRowid",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderRowid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderRowid",
                table: "Products");
        }
    }
}
