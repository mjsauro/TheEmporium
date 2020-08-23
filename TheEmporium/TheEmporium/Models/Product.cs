using System;
using System.ComponentModel.DataAnnotations;

namespace TheEmporium.Models
{
    public class Product 
    {
        public int Id { get; set; }
        public ProductType ProductType { get; set; }
        public Images Images { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public double? Price { get; set; }
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }
        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }
        public int? Quantity { get; set; }
    }
}
