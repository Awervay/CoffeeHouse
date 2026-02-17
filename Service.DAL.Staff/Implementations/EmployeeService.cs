using Contract.Staff.Models.Employee;
using Core.DAL.Staff;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service.Staff.Interfaces;

namespace Service.Staff.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext _context;

    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetEmployeeResponse?> GetAsync(GetEmployeeRequest request)
    {
        var entity = await _context.Employees.FindAsync(request.Id);

        if (entity == null)
            return null;

        return new GetEmployeeResponse
        {
            Id = entity.Id,
            FullName = entity.FullName,
            PositionId = entity.PositionId,
            BranchId = entity.BranchId
        };
    }

    public async Task<IEnumerable<GetEmployeesResponse>> GetAllAsync(GetEmployeesRequest request)
    {
        var query = _context.Employees.AsQueryable();

        if (request.BranchId.HasValue)
            query = query.Where(e => e.BranchId == request.BranchId.Value);

        if (request.PositionId.HasValue)
            query = query.Where(e => e.PositionId == request.PositionId.Value);

        var list = await query.ToListAsync();

        return list.Select(e => new GetEmployeesResponse
        {
            Id = e.Id,
            FullName = e.FullName
        });
    }

    public async Task<CreateEmployeeResponse> CreateAsync(CreateEmployeeRequest request)
    {
        var entity = new Employee
        {
            FullName = request.FullName,
            PositionId = request.PositionId,
            BranchId = request.BranchId
        };

        _context.Employees.Add(entity);
        await _context.SaveChangesAsync();

        return new CreateEmployeeResponse
        {
            Id = entity.Id
        };
    }

    public async Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request)
    {
        var entity = await _context.Employees.FindAsync(request.Id);

        if (entity == null)
            throw new Exception("Employee not found");

        entity.FullName = request.FullName;
        entity.PositionId = request.PositionId;
        entity.BranchId = request.BranchId;

        await _context.SaveChangesAsync();

        return new UpdateEmployeeResponse
        {
            Id = entity.Id
        };
    }

    public async Task<DeleteEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request)
    {
        var entity = await _context.Employees.FindAsync(request.Id);

        if (entity == null)
            return new DeleteEmployeeResponse { Success = false };

        _context.Employees.Remove(entity);
        await _context.SaveChangesAsync();

        return new DeleteEmployeeResponse { Success = true };
    }
}
