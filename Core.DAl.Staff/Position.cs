namespace Core.DAL.Staff;

public class Position // Должность сотрудника
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
