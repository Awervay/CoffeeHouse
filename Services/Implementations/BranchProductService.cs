using Microsoft.EntityFrameworkCore;
using Models.Core.CoffeeHouse;
using Services.Interfaces;
using Data.DbContext;

namespace Services.Implementations;

public class BranchProductService : IBranchProductService
{
    private readonly AppDbContext _context;

    public BranchProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BranchProduct>> GetAllAsync()
        => await _context.BranchProducts.ToListAsync();

    public async Task<BranchProduct?> GetByIdAsync(int id)
        => await _context.BranchProducts.FindAsync(id);

    public async Task<BranchProduct> CreateAsync(BranchProduct entity)
    {
        _context.BranchProducts.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<BranchProduct> UpdateAsync(BranchProduct entity)
    {
        _context.BranchProducts.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.BranchProducts.FindAsync(id);
        if (entity == null)
            return false;

        _context.BranchProducts.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
