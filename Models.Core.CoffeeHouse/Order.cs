using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Core.CoffeeHouse;

public class Order // Заказы
{
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public string? CustomerName { get; set; }
    public DateTime CreatedAt { get; set; }
    public int BranchId { get; set; }
    public Branch? Branch { get; set; }
    public ICollection<OrderItem>? Items { get; set; }
    public OrderStatus Status { get; set; }
}
