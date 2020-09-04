namespace TheEmporium.Models
{
    public class ShoppingCartProduct
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartProduct()
        {
            
        }
        public ShoppingCartProduct(int shoppingCartId, int productId, int quantity)
        {
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}