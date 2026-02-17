using Core.DAL.Branches;

namespace Core.DAL.Staff;

public class Employee //Сотрудник
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public Guid PositionId { get; set; }
    public Position Position { get; set; } = null!;

    public Guid BranchId { get; set; }
    public Branch Branch { get; set; } = null!;
}
