using System;
using System.Threading.Tasks;
using TheEmporium.Models;

namespace TheEmporium.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetShoppingCart(Guid guid);
        Task AddProductToShoppingCartAsync(int productId, int quantity, ShoppingCart cart);
        Task DeleteProductFromShoppingCart(int productId);

    }
}