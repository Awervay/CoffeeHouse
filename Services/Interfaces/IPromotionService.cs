using Models.Core.CoffeeHouse;

namespace Services.Interfaces;

public interface IPromotionService
{
    Task<IEnumerable<Promotion>> GetAllAsync();
    Task<Promotion?> GetByIdAsync(int id);
    Task<Promotion> CreateAsync(Promotion entity);
    Task<Promotion> UpdateAsync(Promotion entity);
    Task<bool> DeleteAsync(int id);
}
