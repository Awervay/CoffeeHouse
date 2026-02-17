namespace Contract.Orders.Models.Order;

public class GetOrdersResponse
{
    public Guid Id { get; set; }
    public int OrderNumber { get; set; }
    public int Status { get; set; }
}
