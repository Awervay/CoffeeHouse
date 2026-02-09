using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Core.CoffeeHouse;

public class OrderItem // Позиция заказа
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public int BranchProductId { get; set; }
    public BranchProduct? BranchProduct { get; set; }

    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; }
}

