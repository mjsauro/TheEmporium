using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheEmporium.Models;
using TheEmporium.Repositories.Interfaces;

namespace TheEmporium.Pages
{
    public class BrowseProductsByTypeModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        public IEnumerable<Product> Products { get; set; }
        public BrowseProductsByTypeModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IActionResult> OnGetAsync(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            Products = await _productRepository.GetProductTypesByIdAsync((int) id);

            return Page();

        }
    }
}