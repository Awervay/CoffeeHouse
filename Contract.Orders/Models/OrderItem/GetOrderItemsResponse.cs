namespace Contract.Orders.Models.OrderItem;

public class GetOrderItemsResponse
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; }
}
