using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShopAPIdotnet.Migrations
{
    public partial class NewStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Products_ProductId",
                table: "OrderRows");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Products",
                newName: "imageUrl");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "totalPrice");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Orders",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Orders",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderRows",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderRows",
                newName: "orderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderRows",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderRows",
                newName: "amount");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_ProductId",
                table: "OrderRows",
                newName: "IX_OrderRows_productId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_OrderId",
                table: "OrderRows",
                newName: "IX_OrderRows_orderId");

            migrationBuilder.AddColumn<DateTime>(
                name: "added",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "product",
                table: "OrderRows",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_orderId",
                table: "OrderRows",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Products_productId",
                table: "OrderRows",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_orderId",
                table: "OrderRows");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Products_productId",
                table: "OrderRows");

            migrationBuilder.DropColumn(
                name: "added",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "year",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "product",
                table: "OrderRows");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "Products",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "totalPrice",
                table: "Orders",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Orders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Orders",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "Orders",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "OrderRows",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "OrderRows",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OrderRows",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "OrderRows",
                newName: "Quantity");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_productId",
                table: "OrderRows",
                newName: "IX_OrderRows_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_orderId",
                table: "OrderRows",
                newName: "IX_OrderRows_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Products_ProductId",
                table: "OrderRows",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
