using Microsoft.Extensions.Logging;
using Trade.Domain.Interfaces.MessageBroker;
using Microsoft.Extensions.Hosting;
using Trade.Domain.Dtos;
using Trade.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Trade.Domain.Entities;

namespace Trade.Infrastructure.MessageBroker.rabbitmq
{
    public class UserWorker : BackgroundService
    {
        private readonly ILogger<UserWorker> _logger;
        private readonly IBus _busControl;
        private readonly IServiceProvider _serviceProvider;

        public UserWorker(ILogger<UserWorker> logger, IBus bus, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _busControl = bus;
            _serviceProvider = serviceProvider;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _busControl.ReceiveAsync<User>("user-auth", "tradeUser", x =>
            {
                Task.Run(() => { DidJob(x); }, stoppingToken);
            });
        }

        private void DidJob(User user)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var scopedService = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                
                scopedService.UserRepository.CreateUser(user);
                scopedService.Complete();
                _logger.LogInformation($"User Id: {user.Id} CompanyName: {user.Username}, User Email: {user.Email}");
            }
           

        }
    }
}
