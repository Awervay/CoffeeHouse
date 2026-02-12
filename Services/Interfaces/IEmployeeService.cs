using Models.Core.CoffeeHouse;

namespace Services.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task<Employee> CreateAsync(Employee entity);
    Task<Employee> UpdateAsync(Employee entity);
    Task<bool> DeleteAsync(int id);
}
