namespace Contract.Branches.Models.Branch;

public class UpdateBranchRequest
{
    public Guid Id { get; set; }

    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public Guid CoffeeChainId { get; set; }
}
