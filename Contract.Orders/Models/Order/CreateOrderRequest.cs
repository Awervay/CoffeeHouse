namespace Contract.Orders.Models.Order;

public class CreateOrderRequest
{
    public string? CustomerName { get; set; }
    public Guid BranchId { get; set; }
}
