using TheEmporium.Data;
using TheEmporium.Repositories.Interfaces;

namespace TheEmporium
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository ProductsRepository { get; }
        public IShoppingCartRepository ShoppingCartRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IProductRepository productsRepository, IShoppingCartRepository shoppingCartRepository)
        {
            _context = context;
            ProductsRepository = productsRepository;
            ShoppingCartRepository = shoppingCartRepository;
        }

        public int Complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}