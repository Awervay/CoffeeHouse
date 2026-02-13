using Contract.Staff.Models.Employee;

namespace Service.Staff.Interfaces;

public interface IEmployeeService
{
    Task<GetEmployeeResponse?> GetAsync(GetEmployeeRequest request);
    Task<IEnumerable<GetEmployeesResponse>> GetAllAsync(GetEmployeesRequest request);
    Task<CreateEmployeeResponse> CreateAsync(CreateEmployeeRequest request);
    Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request);
    Task<DeleteEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request);
}
