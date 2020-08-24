using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheEmporium.Data;
using TheEmporium.Models;
using TheEmporium.Repositories.Interfaces;

namespace TheEmporium.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductTypesByIdAsync(int id)
        {
            return await _context.Product
                .Include(x => x.ProductType)
                .Include(x => x.Images)
                .Where(x => x.ProductType.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Product
                .Include(x => x.ProductType)
                .Include(x => x.Images)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductType
                .Include(x => x.Images)
                .ToListAsync();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            return _context.Product
                .Include(m => m.ProductType)
                .Include(x => x.Images)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}