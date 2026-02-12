using Microsoft.EntityFrameworkCore;
using Models.Core.CoffeeHouse;
using Services.Interfaces;
using Data.DbContext;

namespace Services.Implementations;

public class PositionService : IPositionService
{
    private readonly AppDbContext _context;

    public PositionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Position>> GetAllAsync()
        => await _context.Positions.ToListAsync();

    public async Task<Position?> GetByIdAsync(int id)
        => await _context.Positions.FindAsync(id);

    public async Task<Position> CreateAsync(Position entity)
    {
        _context.Positions.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Position> UpdateAsync(Position entity)
    {
        _context.Positions.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Positions.FindAsync(id);
        if (entity == null)
            return false;

        _context.Positions.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
