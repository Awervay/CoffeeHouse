using Microsoft.EntityFrameworkCore;
using Models.Core.CoffeeHouse;
using Services.Interfaces;
using Data.DbContext;

namespace Services.Implementations;

public class CoffeeChainService : ICoffeeChainService
{
    private readonly AppDbContext _context;

    public CoffeeChainService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CoffeeChain>> GetAllAsync()
        => await _context.CoffeeChains.ToListAsync();

    public async Task<CoffeeChain?> GetByIdAsync(int id)
        => await _context.CoffeeChains.FindAsync(id);

    public async Task<CoffeeChain> CreateAsync(CoffeeChain entity)
    {
        _context.CoffeeChains.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<CoffeeChain> UpdateAsync(CoffeeChain entity)
    {
        _context.CoffeeChains.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.CoffeeChains.FindAsync(id);
        if (entity == null)
            return false;

        _context.CoffeeChains.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
