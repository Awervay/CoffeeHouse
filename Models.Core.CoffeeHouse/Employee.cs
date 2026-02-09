using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Core.CoffeeHouse;

public class Employee // Сотрудник
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public int PositionId { get; set; }
    public Position? Position { get; set; }
    public int BranchId { get; set; }
    public Branch? Branch { get; set; }
}

