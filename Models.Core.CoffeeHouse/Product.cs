using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Core.CoffeeHouse;

public class Product // Продукт
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; 
    public string? Description { get; set; }
    public string Category { get; set; } = string.Empty; 
    public ICollection<BranchProduct> BranchProducts { get; set; } = new List<BranchProduct>();
}

