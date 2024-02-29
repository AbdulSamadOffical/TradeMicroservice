using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trade.Domain.DomainModel;
using Trade.Domain.Dtos;

namespace Trade.Domain.RepositoryContracts
{
    public interface IOrderRepository
    {
        public void CreateOrder(OrderDto order);
        public IEnumerable<OrderDomain> GetAllOrders();
    }
}
