using Models.Core.CoffeeHouse;

namespace Services.Interfaces;

public interface ICoffeeChainService
{
    Task<IEnumerable<CoffeeChain>> GetAllAsync();
    Task<CoffeeChain?> GetByIdAsync(int id);
    Task<CoffeeChain> CreateAsync(CoffeeChain entity);
    Task<CoffeeChain> UpdateAsync(CoffeeChain entity);
    Task<bool> DeleteAsync(int id);
}
