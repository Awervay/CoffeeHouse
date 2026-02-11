using Microsoft.EntityFrameworkCore;
using Models.Core.CoffeeHouse;
using Services.Interfaces;
using Data.DbContext;

namespace Services.Implementations;

public class PromotionService : IPromotionService
{
    private readonly AppDbContext _context;

    public PromotionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Promotion>> GetAllAsync()
        => await _context.Promotions.ToListAsync();

    public async Task<Promotion?> GetByIdAsync(int id)
        => await _context.Promotions.FindAsync(id);

    public async Task<Promotion> CreateAsync(Promotion entity)
    {
        _context.Promotions.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Promotion> UpdateAsync(Promotion entity)
    {
        _context.Promotions.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Promotions.FindAsync(id);
        if (entity == null)
            return false;

        _context.Promotions.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
