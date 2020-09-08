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
        private readonly IProductTypeRepository _productTypeRepository;
        public  IEnumerable<ProductType> ProductType { get; set; }

        public BrowseProductsModel(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            ProductType = await _productTypeRepository.GetProductTypesWithImages();

            return Page();
        }
    }
}