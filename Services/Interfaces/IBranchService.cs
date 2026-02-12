using Models.Core.CoffeeHouse;

namespace Services.Interfaces;

public interface IBranchService
{
    Task<IEnumerable<Branch>> GetAllAsync();
    Task<Branch?> GetByIdAsync(int id);
    Task<Branch> CreateAsync(Branch entity);
    Task<Branch> UpdateAsync(Branch entity);
    Task<bool> DeleteAsync(int id);
}
