using Core.DAL.Branches;

namespace Core.DAL.Orders;

public class Product //Продукт
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Category { get; set; } = string.Empty;

    public ICollection<BranchProduct> BranchProducts { get; set; } = new List<BranchProduct>();
}
