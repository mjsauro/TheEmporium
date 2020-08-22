using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheEmporium.Models;
namespace TheEmporium.Pages
{
    public class ProductModel : PageModel
    {

        private readonly Data.ApplicationDbContext _context;

        public ProductModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public Product Product { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.Include(m => m.ProductType).FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}