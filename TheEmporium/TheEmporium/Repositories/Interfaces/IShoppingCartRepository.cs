using System;
using System.Threading.Tasks;
using TheEmporium.Models;

namespace TheEmporium.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetShoppingCart(Guid guid);
        Task AddProductToShoppingCartAsync(int cartId, int productId, int quantity);
        Task UpdateProductInShoppingCartAsync(ShoppingCartProduct shoppingCartProduct);
        Task DeleteProductFromShoppingCart(int productId);

    }
}