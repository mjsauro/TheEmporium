using System;
using System.Linq;
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
        private readonly IUnitOfWork _unitOfWork;

        public ProductModel(IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _unitOfWork = unitOfWork;
        }

        public Product Product { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            //which is better?
            Product = await _unitOfWork.ProductsRepository.Get((int) id);

            Product = await _unitOfWork.ProductsRepository.Get(
                x => x.Id == (int) id, 
                x => x.Images, x => x.ProductType);

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

            await AddOrUpdateShoppingCart(product, quantity, cartGuid);

            Product = product;
            ViewData["Result"] = "Success";
            return Page();
        }

        private async Task AddOrUpdateShoppingCart(Product product, int quantity, Guid cartGuid)
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