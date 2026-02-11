using Models.Core.CoffeeHouse;

namespace Services.Interfaces;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItem>> GetAllAsync();
    Task<OrderItem?> GetByIdAsync(int id);
    Task<OrderItem> CreateAsync(OrderItem entity);
    Task<OrderItem> UpdateAsync(OrderItem entity);
    Task<bool> DeleteAsync(int id);
}
