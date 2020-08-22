using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheEmporium.Data;
using TheEmporium.Models;
namespace TheEmporium.Pages
{
    public class BrowseProductsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public  IEnumerable<ProductType> ProductType { get; set; }

        public BrowseProductsModel(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> OnGetAsync()
        {
            ProductType = await _context.ProductType.ToListAsync();

            return Page();
        }
    }
}