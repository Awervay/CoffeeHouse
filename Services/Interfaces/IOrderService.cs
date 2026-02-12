using Models.Core.CoffeeHouse;

namespace Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task<Order> CreateAsync(Order entity);
    Task<Order> UpdateAsync(Order entity);
    Task<bool> DeleteAsync(int id);
}
