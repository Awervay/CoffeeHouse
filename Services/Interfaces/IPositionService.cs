using Models.Core.CoffeeHouse;

namespace Services.Interfaces;

public interface IPositionService
{
    Task<IEnumerable<Position>> GetAllAsync();
    Task<Position?> GetByIdAsync(int id);
    Task<Position> CreateAsync(Position entity);
    Task<Position> UpdateAsync(Position entity);
    Task<bool> DeleteAsync(int id);
}
