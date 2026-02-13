using Core.DAL.Branches;

namespace Core.DAL.Orders;

public class Order //Заказы
{
    public Guid Id { get; set; }
    public int OrderNumber { get; set; }
    public string? CustomerName { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid BranchId { get; set; }
    public Branch Branch { get; set; } = null!;

    public int Status { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}

