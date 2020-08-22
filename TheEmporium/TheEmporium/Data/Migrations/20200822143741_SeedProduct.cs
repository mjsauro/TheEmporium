using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheEmporium.Data.Migrations
{
    public partial class SeedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Product", 
                new[] {"Type", "Manufacturer", "Brand", "Name", "Description", "Image", "Price", "DateCreated", "DateModified", "Quantity"}, 
                new object[] { "Electronics","Nintendo of Japan", "Nintendo", "Switch", "Nintendo's latest console", "someImageLink", 200.00, DateTime.Now.AddDays(-1), DateTime.Now, 20 });
            migrationBuilder.InsertData("Product", 
                new[] {"Type", "Manufacturer", "Brand", "Name", "Description", "Image", "Price", "DateCreated", "DateModified", "Quantity"}, 
                new object[] { "Musical Instruments","GibsonUSA", "Gibson", "SG", "Shred like Tony Iommi", "someImageLink", 999.00, DateTime.Now.AddDays(-1), DateTime.Now, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
