namespace Contract.Staff.Models.Employee;

public class UpdateEmployeeRequest
{
    public string FullName { get; set; } = string.Empty;
    public Guid PositionId { get; set; }
    public Guid BranchId { get; set; }
}
