using AutoMapper;
using Core.DAL.Staff;
using Contract.Staff.Models.Employee;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<CreateEmployeeRequest, Employee>();
        CreateMap<UpdateEmployeeRequest, Employee>();

        CreateMap<Employee, GetEmployeeResponse>();
        CreateMap<Employee, GetEmployeesResponse>();
        CreateMap<Employee, CreateEmployeeResponse>();
        CreateMap<Employee, UpdateEmployeeResponse>();
    }
}
