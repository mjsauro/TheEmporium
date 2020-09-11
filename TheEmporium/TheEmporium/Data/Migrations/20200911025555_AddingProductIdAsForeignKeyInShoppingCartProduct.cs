using Microsoft.EntityFrameworkCore.Migrations;

namespace TheEmporium.Data.Migrations
{
    public partial class AddingProductIdAsForeignKeyInShoppingCartProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProducts_ProductId",
                table: "ShoppingCartProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProducts_Product_ProductId",
                table: "ShoppingCartProducts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProducts_Product_ProductId",
                table: "ShoppingCartProducts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartProducts_ProductId",
                table: "ShoppingCartProducts");
        }
    }
}
