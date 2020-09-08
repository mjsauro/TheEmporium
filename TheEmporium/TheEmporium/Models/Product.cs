using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEmporium.Models
{
    public class Product 
    {
        public int Id { get; set; }
        [ForeignKey("Id")]
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
        [ForeignKey("Id")]
        public int ImagesId { get; set; }
        public virtual Images Images { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public double? Price { get; set; }
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }
        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }
    }
}
