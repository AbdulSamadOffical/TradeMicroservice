using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trade.Domain.Dtos;
using Trade.Domain.Interfaces.MessageBroker;
using Trade.Domain.Interfaces;

namespace Trade.Application.AppUsecases.Orders.CreateOrder
{
    public class CreateOrderUsecase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBus _busControl;
        public CreateOrderUsecase(IUnitOfWork unitOfWork, IBus busControl)
        {
            _unitOfWork = unitOfWork;
            _busControl = busControl;
        }

        public  void  CreateOrder(OrderDto orderDto)
        {
            _unitOfWork.OrderRepository.CreateOrder(orderDto);
            _unitOfWork.Complete();
        
        }
    }
}
