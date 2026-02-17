public class BranchProductModel
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
}
