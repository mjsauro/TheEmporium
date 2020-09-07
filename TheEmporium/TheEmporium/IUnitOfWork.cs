using System;
using TheEmporium.Repositories.Interfaces;

namespace TheEmporium
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductsRepository { get; }
        IProductRepository ShoppingCartRepository { get; }
        int Complete();
    }
}