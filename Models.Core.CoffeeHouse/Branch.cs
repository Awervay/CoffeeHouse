using Models.Core.CoffeeHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Core.CoffeeHouse;

public class Branch // Филиал
{
    public int Id { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Address { get; set; }
    public int CoffeeChainId { get; set; }
    public CoffeeChain? CoffeeChain { get; set; }
    public ICollection<Employee>? Employees { get; set; }
    public ICollection<BranchProduct>? BranchProducts { get; set; }
    public ICollection<Promotion>? Promotions { get; set; }
    public ICollection<Order>? Orders { get; set; }
}


