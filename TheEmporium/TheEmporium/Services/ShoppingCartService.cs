using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TheEmporium.Models;
using TheEmporium.Repositories.Interfaces;

namespace TheEmporium.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }


        public Guid GetCartGuid(IHttpContextAccessor context)
        {
            Guid cartGuid;
            bool isThereACartId = context.HttpContext.Request.Cookies.TryGetValue("CartID", out string cartId);

            if (isThereACartId)
            {
                bool isAGuid = Guid.TryParse(cartId, out var parsedGuid);
                cartGuid = isAGuid ? parsedGuid : Guid.NewGuid();
            }
            else
            {
                cartGuid = Guid.NewGuid();
            }

            context.HttpContext.Response.Cookies.Append("CartID", cartGuid.ToString());
            return cartGuid;
        }

        public async Task AddProductToShoppingCart(Product product, int quantity, Guid cartGuid)
        {
            ShoppingCart cart = await _shoppingCartRepository.GetShoppingCart(cartGuid);
            ShoppingCartProduct existingCartProduct = null;

            if (cart.ShoppingCartProducts != null)
            {
                existingCartProduct = cart.ShoppingCartProducts.FirstOrDefault(x => x.ProductId == product.Id);
            }

            if (existingCartProduct != null && existingCartProduct.Quantity > 0)
            {
                existingCartProduct.Quantity += quantity;
                await _shoppingCartRepository.UpdateProductInShoppingCartAsync(existingCartProduct);
            }
            else
            {
                await _shoppingCartRepository.AddProductToShoppingCartAsync(cart.Id, product.Id, quantity);
            }
        }
    }
}