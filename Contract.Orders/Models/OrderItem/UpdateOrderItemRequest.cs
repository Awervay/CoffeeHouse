namespace Contract.Orders.Models.OrderItem;

public class UpdateOrderItemRequest
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; }
}
