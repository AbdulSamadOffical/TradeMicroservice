using Microsoft.Extensions.Logging;
using Trade.Domain.Interfaces.MessageBroker;
using Microsoft.Extensions.Hosting;
using Trade.Domain.Dtos;
using Trade.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Trade.Domain.Entities;
using AutoMapper;

namespace Trade.Infrastructure.MessageBroker.rabbitmq
{
    public class StockWorker : BackgroundService
    {
        private readonly ILogger<UserWorker> _logger;
        private readonly IBus _busControl;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;

        public StockWorker(IMapper mapper, ILogger<UserWorker> logger, IBus bus, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _busControl = bus;
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _busControl.ReceiveAsync<StockDto>("stock-trade", "stock-queue", x =>
            {
                Task.Run(() => { DidJob(x); }, stoppingToken);
            });
        }

        private void DidJob(StockDto stockProduct)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var scopedService = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var stock = _mapper.Map<StockDto, StockProduct>(stockProduct);
                scopedService.StockProductRepository.CreateStock(stock);
                scopedService.Complete();
                _logger.LogInformation($"Stock Price: {stockProduct.Price} User Id: {stockProduct.UserId} CompanyName: {stockProduct.CompanyName}, StockSymbol: {stockProduct.Symbol}");
            }


        }
    }
}
