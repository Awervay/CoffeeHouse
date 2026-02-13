namespace Contract.Branches.Models.CoffeeChain;

public class UpdateCoffeeChainRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
