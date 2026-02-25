using AutoMapper;
using Core.DAL.Branches;
using Contract.Branches.Models.CoffeeChain;

public class CoffeeChainProfile : Profile
{
    public CoffeeChainProfile()
    {
        CreateMap<CreateCoffeeChainRequest, CoffeeChain>();
        CreateMap<UpdateCoffeeChainRequest, CoffeeChain>();

        CreateMap<CoffeeChain, GetCoffeeChainResponse>();
        CreateMap<CoffeeChain, GetCoffeeChainsResponse>();
        CreateMap<CoffeeChain, CreateCoffeeChainResponse>();
        CreateMap<CoffeeChain, UpdateCoffeeChainResponse>();
    }
}
