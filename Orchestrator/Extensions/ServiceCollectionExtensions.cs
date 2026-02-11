using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Implementations;

namespace Orchestrator.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoffeeHouseServices(this IServiceCollection services)
    {
        services.AddScoped<ICoffeeChainService, CoffeeChainService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IBranchProductService, BranchProductService>();
        services.AddScoped<IPositionService, PositionService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IPromotionService, PromotionService>();
        return services;
    }
}
