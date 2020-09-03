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

        public async Task<IActionResult> OnPostAsync(int id)
        {

            if (Request.Cookies.TryGetValue("CartID", out string cookies))
            {
                TempData["CartID"] = cookies;
            }
            else
            {
                Response.Cookies.Append("CartID", Guid.NewGuid().ToString());
                TempData["CartID"] = Request.Cookies["CartID"];
            }
            Product = await _productRepository.GetProductByIdAsync(id);

            return Page();
        }
    }
}