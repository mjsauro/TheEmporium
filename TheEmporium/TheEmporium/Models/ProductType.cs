using System.ComponentModel.DataAnnotations;

namespace TheEmporium.Models
{
    public class ProductType
    {
        public Images Images { get; set; }
        public int Id { get; set; }
        
        [Display(Name="Product Type")]
        public string Name { get; set; }
    }
}
