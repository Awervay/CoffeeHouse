namespace Contract.Branches.Models.Branch;

public class GetBranchesResponse
{
    public Guid Id { get; set; }
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}
