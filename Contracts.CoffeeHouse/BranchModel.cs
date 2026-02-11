using Models.Core.CoffeeHouse;

namespace Contracts.CoffeeHouse
{
    public class BranchModel
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int CoffeeChainId { get; set; }
        public CoffeeChain CoffeeChain { get; set; } = null!;
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<BranchProduct> BranchProducts { get; set; } = new List<BranchProduct>();
        public ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}