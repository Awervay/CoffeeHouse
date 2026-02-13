using System;

namespace Contract.Stocks.Models.Promotion;

public class UpdatePromotionRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid BranchId { get; set; }
}
