using Microsoft.EntityFrameworkCore.Migrations;

namespace TheEmporium.Data.Migrations
{
    public partial class ReplacingImageColumnWithTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
