using System.Threading.Tasks;
using TheEmporium.Data;
using TheEmporium.Repositories.Interfaces;

namespace TheEmporium.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddProductToShoppingCart(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteProductFromShoppingCart(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}