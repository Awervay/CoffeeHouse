namespace Contract.Orders.Models.Order;

public class GetOrderResponse
{
    public Guid Id { get; set; }
    public int OrderNumber { get; set; }
    public string? CustomerName { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid BranchId { get; set; }
    public int Status { get; set; }
}
