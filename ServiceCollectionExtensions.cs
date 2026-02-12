using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Implementations;

namespace Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoffeeHouseServices(this IServiceCollection services)
    {
        services.AddScoped<ICoffeeChainService, CoffeeChainService>();
        services.AddScoped<IBranchService, BranchService>();

        return services;
    }
}
