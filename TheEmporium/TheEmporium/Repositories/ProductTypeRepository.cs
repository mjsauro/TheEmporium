using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheEmporium.Data;
using TheEmporium.Models;
using TheEmporium.Repositories.Interfaces;

namespace TheEmporium.Repositories
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesWithImages()
        {
            return await Context.ProductType
                .Include(x => x.Images)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}