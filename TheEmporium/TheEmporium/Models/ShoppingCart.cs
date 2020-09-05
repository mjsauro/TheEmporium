using System;
using System.Collections.Generic;

namespace TheEmporium.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Guid CartGuid { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; }

        public ShoppingCart(Guid cartGuid)
        {
            CartGuid = cartGuid;
        }
    }
}