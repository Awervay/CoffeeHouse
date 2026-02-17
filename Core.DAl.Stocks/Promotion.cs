using Core.DAL.Branches;

namespace Core.DAL.Stocks;

public class Promotion //Акции - спец. предложения
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Guid BranchId { get; set; }
    public Branch Branch { get; set; } = null!;
}
