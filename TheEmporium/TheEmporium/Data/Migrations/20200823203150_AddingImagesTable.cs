using Microsoft.EntityFrameworkCore.Migrations;

namespace TheEmporium.Data.Migrations
{
    public partial class AddingImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImagesId",
                table: "ProductType",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImagesId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ImagesId",
                table: "ProductType",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ImagesId",
                table: "Product",
                column: "ImagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Images_ImagesId",
                table: "Product",
                column: "ImagesId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductType_Images_ImagesId",
                table: "ProductType",
                column: "ImagesId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Images_ImagesId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductType_Images_ImagesId",
                table: "ProductType");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_ProductType_ImagesId",
                table: "ProductType");

            migrationBuilder.DropIndex(
                name: "IX_Product_ImagesId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImagesId",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "ImagesId",
                table: "Product");
        }
    }
}
