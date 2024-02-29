using Microsoft.AspNetCore.Mvc;
using Trade.Application.AppUsecases.Orders.CreateOrder;
using Trade.Application.AppUsecases.Orders.GetOrder;
using Trade.Application.AppUsecases.Stocks.GetStocks;
using Trade.Domain.DomainEntities;
using Trade.Domain.DomainModel;
using Trade.Domain.Dtos;
using Trade.Domain.Exceptions;

namespace TradeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController: BaseController
    {
        private readonly ILogger<OrderController> _logger;
 
        private readonly CreateOrderUsecase _createOrderUsecase;
        private readonly GetOrderUsecase _getOrderUsecase;

        public OrderController(ILogger<OrderController> logger, CreateOrderUsecase createStockUseCase,
            GetOrderUsecase getOrderUsecase):base()
        {
            _logger = logger;
            _createOrderUsecase = createStockUseCase;
            _getOrderUsecase = getOrderUsecase;


        }

        [HttpPost("create")]
        public  IActionResult CreateOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                
                _createOrderUsecase.CreateOrder(orderDto);

                return Ok(new StockResponseDto<OrderDto>() { Message = "Order created successfully", Data = orderDto });


            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred: {Message}",  ex.Message);
                throw new NotFoundException(ex.Message);
            }


        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var orders = _getOrderUsecase.GetAllOrder();
                return Ok(new StockResponseDtoList<OrderDomain>() { Message = null, Data = orders });
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred: {Message}", ex.Message);
                throw new NotFoundException(ex.Message);
            }


        }
    }
}
