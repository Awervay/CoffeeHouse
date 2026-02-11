using Models.Core.CoffeeHouse;

namespace Services.Interfaces;

public interface IBranchProductService
{
    Task<IEnumerable<BranchProduct>> GetAllAsync();
    Task<BranchProduct?> GetByIdAsync(int id);
    Task<BranchProduct> CreateAsync(BranchProduct entity);
    Task<BranchProduct> UpdateAsync(BranchProduct entity);
    Task<bool> DeleteAsync(int id);
}
