namespace Core.DAL.Branches;

public class BranchProduct //Продукция в филлиалах
{
    public Guid Id { get; set; }

    public Guid BranchId { get; set; }
    public Branch Branch { get; set; } = null!;

    public Guid ProductId { get; set; }

    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
}
