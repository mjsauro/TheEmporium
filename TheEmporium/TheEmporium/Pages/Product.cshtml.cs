using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheEmporium.Models;
using TheEmporium.Repositories.Interfaces;

namespace TheEmporium.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ProductModel(IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository)
        {
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public Product Product { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _productRepository.GetProductByIdAsync((int)id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Product product, int quantity)
        {
            
            Guid cartGuid = GetCartGuid();
            Response.Cookies.Append("CartID", cartGuid.ToString());
            TempData["CartID"] = cartGuid.ToString();

            ShoppingCart cart = await _shoppingCartRepository.GetShoppingCart(cartGuid);

            //TODO if it already exists in cart, we have to update the quantity rather than insert
            await _shoppingCartRepository.AddProductToShoppingCartAsync(cart.Id, product.Id, quantity);

            Product = product;
            ViewData["Result"] = "Success";
            return Page();
        }

        private Guid GetCartGuid()
        {
            bool isThereACartId = Request.Cookies.TryGetValue("CartID", out string cartGuid);

            if (isThereACartId)
            {
                bool isAGuid = Guid.TryParse(cartGuid, out var cartId);
                return isAGuid ? cartId : Guid.NewGuid();
            }

            return Guid.NewGuid();
        }
    }
}