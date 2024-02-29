using AutoMapper;
using Trade.Domain.DomainEntities;
using Trade.Domain.DomainModel;
using Trade.Domain.Dtos;
using Trade.Domain.Entities;
using Trade.Domain.Interfaces;
using Trade.Domain.RepositoryContracts;

namespace Trade.Infrastructure.Persistence.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly IMapper _mapper;
        protected readonly ApplicationContext _context;
        private readonly IGenericRepository<Order> _order;
      
        public OrderRepository(IMapper mapper, ApplicationContext context, IGenericRepository<Order> order) 
        {
            _context = context;
            _order = order;
            _mapper = mapper;
     
        }
        public void CreateOrder(OrderDto order)
        {
            var placeOrder = _mapper.Map<OrderDto,Order>(order);
            _order.Add(placeOrder);
        }
        public IEnumerable<OrderDomain> GetAllOrders()
        {
            var orders = _order.GetAll();
            return _mapper.Map<IEnumerable<OrderDomain>>(orders);
            
        }
    }
}
