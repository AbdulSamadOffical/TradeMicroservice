using Trade.Domain.RepositoryContracts;

namespace Trade.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        int Complete ();
        IStockProductRepository StockProductRepository { get; }
        IUserRepository UserRepository { get; }
        IOrderRepository OrderRepository { get; }
    }
}
