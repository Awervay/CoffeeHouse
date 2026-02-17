using Contract.Branches.Models.CoffeeChain;

namespace Service.Branches.Interfaces;

public interface ICoffeeChainService
{
    Task<GetCoffeeChainResponse?> GetAsync(GetCoffeeChainRequest request);
    Task<IEnumerable<GetCoffeeChainsResponse>> GetAllAsync(GetCoffeeChainsRequest request);
    Task<CreateCoffeeChainResponse> CreateAsync(CreateCoffeeChainRequest request);
    Task<UpdateCoffeeChainResponse> UpdateAsync(UpdateCoffeeChainRequest request);
    Task<DeleteCoffeeChainResponse> DeleteAsync(DeleteCoffeeChainRequest request);
}
