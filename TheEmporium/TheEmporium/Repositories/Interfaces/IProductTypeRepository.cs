using System.Collections.Generic;
using System.Threading.Tasks;
using TheEmporium.Models;

namespace TheEmporium.Repositories.Interfaces
{
    public interface IProductTypeRepository : IRepository<ProductType>
    {
        Task<IEnumerable<ProductType>> GetProductTypesWithImages();

    }
}