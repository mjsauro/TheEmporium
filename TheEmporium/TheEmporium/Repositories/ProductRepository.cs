using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheEmporium.Data;
using TheEmporium.Models;
using TheEmporium.Repositories.Interfaces;

namespace TheEmporium.Repositories
{
    
    public class ProductRepository : Repository<Product>,  IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductTypesByIdAsync(int id)
        {
            return await Context.Product
                .Include(x => x.ProductType)
                .Include(x => x.Images)
                .Where(x => x.ProductType.Id == id)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await Context.Product
                .Include(x => x.ProductType)
                .Include(x => x.Images)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            return await Context.ProductType
                .Include(x => x.Images)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            return Context.Product
                .Include(m => m.ProductType)
                .Include(x => x.Images)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (ProductExists(product.Id))
            {
                Context.Entry(product).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            else
            {
                throw new DBConcurrencyException();
            }
        }

        public async Task<int> AddProductAsync(Product product)
        {
            await Context.AddAsync(product);
            return await Context.SaveChangesAsync();
        }

        private bool ProductExists(int id)
        {
            return Context.Product.Any(e => e.Id == id);
        }

       
    }
}