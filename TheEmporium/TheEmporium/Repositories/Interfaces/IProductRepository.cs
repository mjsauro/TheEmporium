using System.Collections.Generic;
using System.Threading.Tasks;
using TheEmporium.Models;

namespace TheEmporium.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<ProductType>> GetProductTypesAsync();

        Task<Product> GetProductByIdAsync(int id);
    }
}