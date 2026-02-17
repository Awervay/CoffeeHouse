namespace Contract.Orders.Models.OrderItem;

public class CreateOrderItemRequest
{
    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; }
    public Guid OrderId { get; set; }
    public Guid BranchProductId { get; set; }
}
