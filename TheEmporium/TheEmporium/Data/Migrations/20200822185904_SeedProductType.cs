using Microsoft.EntityFrameworkCore.Migrations;

namespace TheEmporium.Data.Migrations
{
    public partial class SeedProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("ProductType", "Name", "Electronics");
            migrationBuilder.InsertData("ProductType", "Name", "Musical Instruments");
            migrationBuilder.UpdateData("Product", "Id", 1, "ProductTypeId", 1);
            migrationBuilder.UpdateData("Product", "Id", 2, "ProductTypeId", 2);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
