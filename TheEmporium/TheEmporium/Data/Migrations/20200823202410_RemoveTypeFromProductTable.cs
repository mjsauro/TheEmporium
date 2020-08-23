using Microsoft.EntityFrameworkCore.Migrations;

namespace TheEmporium.Data.Migrations
{
    public partial class RemoveTypeFromProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
