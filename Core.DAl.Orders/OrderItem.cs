using Core.DAL.Branches;

namespace Core.DAL.Orders;

public class OrderItem // Позиция заказа
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; }

    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public Guid BranchProductId { get; set; }
    public BranchProduct BranchProduct { get; set; } = null!;
}

