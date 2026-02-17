namespace Contract.Staff.Models.Employee;

public class GetEmployeesRequest
{
    public Guid? BranchId { get; set; }
    public Guid? PositionId { get; set; }
}
