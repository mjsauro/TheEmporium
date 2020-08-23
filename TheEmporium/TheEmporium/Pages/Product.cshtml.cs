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

        public ProductModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product Product { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _productRepository.GetProductByIdAsync((int) id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}