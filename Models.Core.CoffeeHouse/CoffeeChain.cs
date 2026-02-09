using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Core.CoffeeHouse;

public class CoffeeChain // Сеть кофейн
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Branch>? Branches { get; set; }
}

