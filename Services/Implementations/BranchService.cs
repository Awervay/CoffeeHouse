using Microsoft.EntityFrameworkCore;
using Models.Core.CoffeeHouse;
using Services.Interfaces;
using Data.DbContext;

namespace Services.Implementations;

public class BranchService : IBranchService
{
    private readonly AppDbContext _context;

    public BranchService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Branch>> GetAllAsync()
        => await _context.Branches.ToListAsync();

    public async Task<Branch?> GetByIdAsync(int id)
        => await _context.Branches.FindAsync(id);

    public async Task<Branch> CreateAsync(Branch entity)
    {
        _context.Branches.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Branch> UpdateAsync(Branch entity)
    {
        _context.Branches.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Branches.FindAsync(id);
        if (entity == null)
            return false;

        _context.Branches.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
