using Microsoft.Extensions.DependencyInjection;

using Service.Branches.Interfaces;
using Service.Branches.Implementations;

using Service.Orders.Interfaces;
using Service.Orders.Implementations;

using Service.Staff.Interfaces;
using Service.Staff.Implementations;

using Service.Stocks.Interfaces;
using Service.Stocks.Implementations;

namespace API.Gateway.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoffeeHouseServices(this IServiceCollection services)
    {
        // Branches
        services.AddScoped<IBranchService, BranchService>();
        services.AddScoped<ICoffeeChainService, CoffeeChainService>();
        services.AddScoped<IBranchProductService, BranchProductService>();

        // Staff
        services.AddScoped<IPositionService, PositionService>();
        services.AddScoped<IEmployeeService, EmployeeService>();

        // Orders
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IProductService, ProductService>();

        // Stocks
        services.AddScoped<IPromotionService, PromotionService>();

        return services;
    }
}
