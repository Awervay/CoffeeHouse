using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Core.CoffeeHouse;

public class Promotion // Акции - спец. предложения
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty; 
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int BranchId { get; set; }
    public Branch Branch { get; set; } = null!;
}
