using Contract.Orders.Models.OrderItem;
using Core.DAL.Orders;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service.Orders.Interfaces;

namespace Service.Orders.Implementations;

public class OrderItemService : IOrderItemService
{
    private readonly AppDbContext _context;

    public OrderItemService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetOrderItemResponse?> GetAsync(GetOrderItemRequest request)
    {
        var entity = await _context.OrderItems.FindAsync(request.Id);

        if (entity == null)
            return null;

        return new GetOrderItemResponse
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            PriceAtPurchase = entity.PriceAtPurchase,
            OrderId = entity.OrderId,
            BranchProductId = entity.BranchProductId
        };
    }

    public async Task<IEnumerable<GetOrderItemsResponse>> GetAllAsync(GetOrderItemsRequest request)
    {
        var query = _context.OrderItems.AsQueryable();

        if (request.OrderId.HasValue)
            query = query.Where(i => i.OrderId == request.OrderId.Value);

        var list = await query.ToListAsync();

        return list.Select(i => new GetOrderItemsResponse
        {
            Id = i.Id,
            Quantity = i.Quantity,
            PriceAtPurchase = i.PriceAtPurchase
        });
    }

    public async Task<CreateOrderItemResponse> CreateAsync(CreateOrderItemRequest request)
    {
        var entity = new OrderItem
        {
            Quantity = request.Quantity,
            PriceAtPurchase = request.PriceAtPurchase,
            OrderId = request.OrderId,
            BranchProductId = request.BranchProductId
        };

        _context.OrderItems.Add(entity);
        await _context.SaveChangesAsync();

        return new CreateOrderItemResponse
        {
            Id = entity.Id
        };
    }

    public async Task<UpdateOrderItemResponse> UpdateAsync(UpdateOrderItemRequest request)
    {
        var entity = await _context.OrderItems.FindAsync(request.Id);

        if (entity == null)
            throw new Exception("Order item not found");

        entity.Quantity = request.Quantity;
        entity.PriceAtPurchase = request.PriceAtPurchase;

        await _context.SaveChangesAsync();

        return new UpdateOrderItemResponse
        {
            Id = entity.Id
        };
    }

    public async Task<DeleteOrderItemResponse> DeleteAsync(DeleteOrderItemRequest request)
    {
        var entity = await _context.OrderItems.FindAsync(request.Id);

        if (entity == null)
            return new DeleteOrderItemResponse { Success = false };

        _context.OrderItems.Remove(entity);
        await _context.SaveChangesAsync();

        return new DeleteOrderItemResponse { Success = true };
    }
}
