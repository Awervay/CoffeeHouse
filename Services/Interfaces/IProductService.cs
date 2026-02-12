using Models.Core.CoffeeHouse;

namespace Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product entity);
    Task<Product> UpdateAsync(Product entity);
    Task<bool> DeleteAsync(int id);
}
