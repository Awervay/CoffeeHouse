namespace Contract.Staff.Models.Employee;

public class GetEmployeeResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public Guid PositionId { get; set; }
    public Guid BranchId { get; set; }
}
