using System;
using System.Collections.Generic;

namespace TheEmporium.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Guid CartGuid { get; set; }
        public ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    }
}