using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheEmporium.Models;
using TheEmporium.Repositories.Interfaces;
using TheEmporium.Services;

namespace TheEmporium.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IHttpContextAccessor _httpContext;

        public ProductModel(IProductRepository productRepository, IShoppingCartService shoppingCartService, IHttpContextAccessor httpContext)
        {
            _productRepository = productRepository;
            _shoppingCartService = shoppingCartService;
            _httpContext = httpContext;
        }

        public Product Product { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _productRepository.GetProductByIdWithProductTypeAndImage((int)id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Product product, int quantity)
        {
            Guid cartGuid = _shoppingCartService.GetCartGuid(_httpContext);
            TempData["CartID"] = cartGuid.ToString();
            
            try
            {
                await _shoppingCartService.AddProductToShoppingCart(product, quantity, cartGuid);
                ViewData["Result"] = "Success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Product = product;
            return Page();
        }
    }
}