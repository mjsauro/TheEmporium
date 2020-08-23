using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheEmporium.Models;
using TheEmporium.Repositories.Interfaces;

namespace TheEmporium.Pages
{
    public class BrowseProductsModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        public  IEnumerable<ProductType> ProductType { get; set; }

        public BrowseProductsModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            ProductType = await _productRepository.GetProductTypesAsync();

            return Page();
        }
    }
}