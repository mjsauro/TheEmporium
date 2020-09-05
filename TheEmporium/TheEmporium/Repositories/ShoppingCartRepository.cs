using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheEmporium.Data;
using TheEmporium.Models;
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

        public async Task<ShoppingCart> GetShoppingCart(Guid guid)
        {
            ShoppingCart shoppingCart = await _context.ShoppingCart.Where(x => x.CartGuid == guid).FirstOrDefaultAsync();

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart(guid);
                var now = DateTime.Now;
                shoppingCart.DateCreated = now;
                shoppingCart.DateModified = now;
                await _context.ShoppingCart.AddAsync(shoppingCart);
                await _context.SaveChangesAsync();
            }

            return shoppingCart;
        }

        public async Task AddProductToShoppingCartAsync(int cartId, int productId, int quantity)
        { 
            ShoppingCartProduct shoppingCartProduct = new ShoppingCartProduct(cartId, productId, quantity);
            await _context.ShoppingCartProducts.AddAsync(shoppingCartProduct);
            await _context.SaveChangesAsync();
        }


        public Task DeleteProductFromShoppingCart(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}