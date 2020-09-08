using System;
using TheEmporium.Repositories.Interfaces;

namespace TheEmporium
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductsRepository { get; }
        IShoppingCartRepository ShoppingCartRepository { get; }
        int Complete();
    }
}