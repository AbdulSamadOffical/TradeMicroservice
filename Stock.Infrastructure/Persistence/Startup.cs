using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Trade.Infrastructure.Persistence;
using Trade.Domain.RepositoryContracts;
using Trade.Infrastructure.Persistence.Repository;
using Trade.Domain.Interfaces;
using Trade.Application.AppUsecases.Stocks.GetStocks;
using Trade.Application.AppUsecases.Stocks.CreateStocks;
using Trade.Application.AppUsecases.Stocks.UpdateStock;
using Trade.Application.AppUsecases.Stocks.DeleteStock;
using Trade.Infrastructure.MessageBroker.rabbitmq;
using Trade.Infrastructure.MessageBroker;
using Microsoft.Extensions.Logging;
using Trade.Domain.Interfaces.MessageBroker;
using Trade.Application.AppUsecases.Orders.CreateOrder;
using Trade.Application.AppUsecases.Orders.GetOrder;
using Trade.Infrastructure.Context;
public static class Startup
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
            , b => b.MigrationsAssembly("TradeAPI")));

      
        services.AddScoped(typeof(IGenericRepository<>), typeof(InMemoryGenericRepository<>));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IStockProductRepository, StockProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<CreateOrderUsecase>();
        services.AddScoped<GetStocksUseCase>();
        services.AddScoped<CreateStockUsecase>();
        services.AddScoped<UpdateStockUseCase>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<GetOrderUsecase>();
        services.AddScoped<DeleteStockUsecase>();
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentContext, CurrentUser>();
        services.AddSingleton<IBus>(sp =>
        {
            var logger = sp.GetRequiredService<ILogger<IBus>>();
            return RabbitHutch.CreateBus("localhost", logger);
        });
        services.AddHostedService<UserWorker>();
        services.AddHostedService<StockWorker>();

    }

}