using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheEmporium.Data;
using TheEmporium.Models;

namespace TheEmporium.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public ShoppingCart ShoppingCart { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShoppingCart = await _context.ShoppingCart
                .Include(x => x.ShoppingCartProducts)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);


            if (ShoppingCart == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
