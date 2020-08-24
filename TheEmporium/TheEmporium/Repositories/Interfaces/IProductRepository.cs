using System.Collections.Generic;
using System.Threading.Tasks;
using TheEmporium.Models;

namespace TheEmporium.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductType>> GetProductTypesAsync();
        Task<IEnumerable<Product>> GetProductTypesByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        
    }
}