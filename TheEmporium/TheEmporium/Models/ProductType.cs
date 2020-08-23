using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
