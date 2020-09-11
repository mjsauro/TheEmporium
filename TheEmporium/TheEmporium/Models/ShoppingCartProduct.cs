using System.ComponentModel.DataAnnotations.Schema;

namespace TheEmporium.Models
{
    public class ShoppingCartProduct
    {
        public int Id { get; set; }
        [ForeignKey("Id")]
        public int ShoppingCartId { get; set; }
        [ForeignKey("Id")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartProduct(int shoppingCartId, int productId, int quantity)
        {
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}