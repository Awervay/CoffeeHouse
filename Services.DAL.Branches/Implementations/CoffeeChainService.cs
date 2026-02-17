using Contract.Branches.Models.CoffeeChain;
using Core.DAL.Branches;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service.Branches.Interfaces;

namespace Service.Branches.Implementations;

public class CoffeeChainService : ICoffeeChainService
{
    private readonly AppDbContext _context;

    public CoffeeChainService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetCoffeeChainResponse?> GetAsync(GetCoffeeChainRequest request)
    {
        var entity = await _context.CoffeeChains.FindAsync(request.Id);

        if (entity == null)
            return null;

        return new GetCoffeeChainResponse
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public async Task<IEnumerable<GetCoffeeChainsResponse>> GetAllAsync(GetCoffeeChainsRequest request)
    {
        var chains = await _context.CoffeeChains.ToListAsync();

        return chains.Select(c => new GetCoffeeChainsResponse
        {
            Id = c.Id,
            Name = c.Name
        });
    }

    public async Task<CreateCoffeeChainResponse> CreateAsync(CreateCoffeeChainRequest request)
    {
        var entity = new CoffeeChain
        {
            Name = request.Name
        };

        _context.CoffeeChains.Add(entity);
        await _context.SaveChangesAsync();

        return new CreateCoffeeChainResponse
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public async Task<UpdateCoffeeChainResponse> UpdateAsync(UpdateCoffeeChainRequest request)
    {
        var entity = await _context.CoffeeChains.FindAsync(request.Id);

        if (entity == null)
            throw new Exception("Coffee chain not found");

        entity.Name = request.Name;

        await _context.SaveChangesAsync();

        return new UpdateCoffeeChainResponse
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public async Task<DeleteCoffeeChainResponse> DeleteAsync(DeleteCoffeeChainRequest request)
    {
        var entity = await _context.CoffeeChains.FindAsync(request.Id);

        if (entity == null)
            return new DeleteCoffeeChainResponse { Success = false };

        _context.CoffeeChains.Remove(entity);
        await _context.SaveChangesAsync();

        return new DeleteCoffeeChainResponse { Success = true };
    }
}
