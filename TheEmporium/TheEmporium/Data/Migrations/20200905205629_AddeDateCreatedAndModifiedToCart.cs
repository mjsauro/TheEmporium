using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheEmporium.Data.Migrations
{
    public partial class AddeDateCreatedAndModifiedToCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "ShoppingCart");
        }
    }
}
