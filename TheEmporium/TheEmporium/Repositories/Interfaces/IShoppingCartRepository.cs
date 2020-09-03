using System.Threading.Tasks;

namespace TheEmporium.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task AddProductToShoppingCart(int productId);
        Task DeleteProductFromShoppingCart(int productId);

    }
}