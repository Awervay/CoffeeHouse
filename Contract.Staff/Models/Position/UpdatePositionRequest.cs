namespace Contract.Staff.Models.Position;

public class UpdatePositionRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
