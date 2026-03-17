namespace Contract.Orders.Models.OrderItem;

public class UpdateOrderItemRequest
{
    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; }
}
