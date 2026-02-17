namespace Contract.Orders.Models.Order;

public class UpdateOrderRequest
{
    public Guid Id { get; set; }
    public int Status { get; set; }
}
