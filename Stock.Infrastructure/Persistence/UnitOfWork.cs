using Trade.Domain.Interfaces;
using Trade.Domain.RepositoryContracts;


namespace Trade.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

   
        public UnitOfWork(ApplicationContext context, IStockProductRepository productRepository, IUserRepository userRepository,
            IOrderRepository orderRepository) 
        {
            _context = context;
            StockProductRepository = productRepository;
            UserRepository = userRepository;
            OrderRepository = orderRepository;
        }

        public IStockProductRepository StockProductRepository { get; }
        public IUserRepository UserRepository { get; }
        public IOrderRepository OrderRepository { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

    }
}
