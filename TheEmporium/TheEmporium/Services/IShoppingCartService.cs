using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TheEmporium.Models;

namespace TheEmporium.Services
{
    public interface IShoppingCartService
    {
        Guid GetCartGuid(IHttpContextAccessor context);
        Task AddProductToShoppingCart(Product product, int quantity, Guid cartGuid);
    }
}