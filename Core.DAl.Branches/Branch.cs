namespace Core.DAL.Branches;

public class Branch //Филлиал
{
    public Guid Id { get; set; }

    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public Guid CoffeeChainId { get; set; }
    public CoffeeChain CoffeeChain { get; set; } = null!;

    public ICollection<BranchProduct> BranchProducts { get; set; } = new List<BranchProduct>();
}
