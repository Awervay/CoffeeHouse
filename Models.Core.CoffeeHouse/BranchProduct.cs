using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Core.CoffeeHouse;

public class BranchProduct // Продукция в филиалах
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public Branch Branch { get; set; } = null!; 
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!; 
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

