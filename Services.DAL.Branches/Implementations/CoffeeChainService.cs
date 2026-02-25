using AutoMapper;
using Contract.Branches.Models.CoffeeChain;
using Core.DAL.Branches;
using Data.DbContext;
using Service.Branches.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.Branches.Implementations;

public class CoffeeChainService : ICoffeeChainService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CoffeeChainService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetCoffeeChainResponse?> GetAsync(GetCoffeeChainRequest request)
    {
        var entity = await _context.CoffeeChains.FindAsync(request.Id);
        return entity == null ? null : _mapper.Map<GetCoffeeChainResponse>(entity);
    }

    public async Task<IEnumerable<GetCoffeeChainsResponse>> GetAllAsync(GetCoffeeChainsRequest request)
    {
        var chains = await _context.CoffeeChains.ToListAsync();
        return _mapper.Map<IEnumerable<GetCoffeeChainsResponse>>(chains);
    }

    public async Task<CreateCoffeeChainResponse> CreateAsync(CreateCoffeeChainRequest request)
    {
        var entity = _mapper.Map<CoffeeChain>(request);

        _context.CoffeeChains.Add(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<CreateCoffeeChainResponse>(entity);
    }

    public async Task<UpdateCoffeeChainResponse> UpdateAsync(Guid id, UpdateCoffeeChainRequest request)
    {
        var entity = await _context.CoffeeChains.FindAsync(id);
        if (entity == null)
            throw new Exception("Coffee chain not found");

        _mapper.Map(request, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<UpdateCoffeeChainResponse>(entity);
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
