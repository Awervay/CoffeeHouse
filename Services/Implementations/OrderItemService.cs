using Microsoft.EntityFrameworkCore;
using Models.Core.CoffeeHouse;
using Services.Interfaces;
using Data.DbContext;

namespace Services.Implementations;

public class OrderItemService : IOrderItemService
{
    private readonly AppDbContext _context;

    public OrderItemService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderItem>> GetAllAsync()
        => await _context.OrderItems.ToListAsync();

    public async Task<OrderItem?> GetByIdAsync(int id)
        => await _context.OrderItems.FindAsync(id);

    public async Task<OrderItem> CreateAsync(OrderItem entity)
    {
        _context.OrderItems.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<OrderItem> UpdateAsync(OrderItem entity)
    {
        _context.OrderItems.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.OrderItems.FindAsync(id);
        if (entity == null)
            return false;

        _context.OrderItems.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
