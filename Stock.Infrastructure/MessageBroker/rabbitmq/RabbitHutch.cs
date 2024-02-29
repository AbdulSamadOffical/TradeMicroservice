using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Trade.Domain.Interfaces.MessageBroker;
using Trade.Infrastructure.MessageBroker.rabbitmq;


namespace Trade.Infrastructure.MessageBroker
{
    public class RabbitHutch
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _channel;
        public static IBus CreateBus(string hostName, ILogger _logger)
        {
            _factory = new ConnectionFactory
            {
                HostName = hostName,
                DispatchConsumersAsync = true
            };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
          
            return new RabbitBus(_channel, _logger);
        }
    }
}
