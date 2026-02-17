namespace Contract.Branches.Models.BranchProduct;

public class GetBranchProductsRequest
{
    public Guid? BranchId { get; set; }
    public bool? OnlyAvailable { get; set; }
}
