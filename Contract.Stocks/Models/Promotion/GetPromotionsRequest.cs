namespace Contract.Stocks.Models.Promotion;

public class GetPromotionsRequest
{
    public Guid? BranchId { get; set; }
    public DateTime? ActiveOnDate { get; set; }
}
