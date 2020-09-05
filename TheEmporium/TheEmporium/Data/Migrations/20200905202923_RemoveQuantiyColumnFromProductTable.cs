using Microsoft.EntityFrameworkCore.Migrations;

namespace TheEmporium.Data.Migrations
{
    public partial class RemoveQuantiyColumnFromProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProduct_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartProduct",
                table: "ShoppingCartProduct");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "ShoppingCartProduct",
                newName: "ShoppingCartProducts");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartProduct_ShoppingCartId",
                table: "ShoppingCartProducts",
                newName: "IX_ShoppingCartProducts_ShoppingCartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartProducts",
                table: "ShoppingCartProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProducts_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartProducts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProducts_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartProducts",
                table: "ShoppingCartProducts");

            migrationBuilder.RenameTable(
                name: "ShoppingCartProducts",
                newName: "ShoppingCartProduct");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartProducts_ShoppingCartId",
                table: "ShoppingCartProduct",
                newName: "IX_ShoppingCartProduct_ShoppingCartId");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartProduct",
                table: "ShoppingCartProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProduct_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartProduct",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
