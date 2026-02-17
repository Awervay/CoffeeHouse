namespace Contract.Orders.Models.OrderItem;

public class GetOrderItemResponse
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; }
    public Guid OrderId { get; set; }
    public Guid BranchProductId { get; set; }
}
