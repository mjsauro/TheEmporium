using System.ComponentModel.DataAnnotations;

namespace TheEmporium.Models.DTOs
{
    public class ProductTypeDto
    {
        public int Id { get; set; }

        [Display(Name = "Product Type")]
        public string Name { get; set; }
    }
}
