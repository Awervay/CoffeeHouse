namespace Contract.Orders.Models.Order;

public class GetOrdersRequest
{
    public Guid? BranchId { get; set; }
    public int? Status { get; set; }
}
