using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trade.Domain.Dtos;
using Trade.Domain.Interfaces.MessageBroker;
using Trade.Domain.Interfaces;
using Trade.Domain.DomainModel;

namespace Trade.Application.AppUsecases.Orders.GetOrder
{
    public class GetOrderUsecase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBus _busControl;
        public GetOrderUsecase(IUnitOfWork unitOfWork, IBus busControl)
        {
            _unitOfWork = unitOfWork;
            _busControl = busControl;
        }

        public IEnumerable<OrderDomain> GetAllOrder()
        {
            var orders = _unitOfWork.OrderRepository.GetAllOrders();
            _unitOfWork.Complete();
            return orders;
        }
    }
}
