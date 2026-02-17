using Contract.Orders.Models.Order;
using Core.DAL.Orders;
using Core.DAL.Orders.Enum;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service.Orders.Interfaces;

namespace Service.Orders.Implementations;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetOrderResponse?> GetAsync(GetOrderRequest request)
    {
        var entity = await _context.Orders.FindAsync(request.Id);

        if (entity == null)
            return null;

        return new GetOrderResponse
        {
            Id = entity.Id,
            OrderNumber = entity.OrderNumber,
            CustomerName = entity.CustomerName,
            CreatedAt = entity.CreatedAt,
            BranchId = entity.BranchId,
            Status = entity.Status
        };
    }

    public async Task<IEnumerable<GetOrdersResponse>> GetAllAsync(GetOrdersRequest request)
    {
        var query = _context.Orders.AsQueryable();

        if (request.BranchId.HasValue)
            query = query.Where(o => o.BranchId == request.BranchId.Value);

        if (request.Status.HasValue)
            query = query.Where(o => o.Status == request.Status.Value);

        var list = await query.ToListAsync();

        return list.Select(o => new GetOrdersResponse
        {
            Id = o.Id,
            OrderNumber = o.OrderNumber,
            Status = o.Status
        });
    }

    public async Task<CreateOrderResponse> CreateAsync(CreateOrderRequest request)
    {
        var entity = new Order
        {
            OrderNumber = await GenerateOrderNumberAsync(),
            CustomerName = request.CustomerName,
            CreatedAt = DateTime.UtcNow,
            BranchId = request.BranchId,
            Status = (int)OrderStatus.New
        };

        _context.Orders.Add(entity);
        await _context.SaveChangesAsync();

        return new CreateOrderResponse
        {
            Id = entity.Id,
            OrderNumber = entity.OrderNumber
        };
    }

    public async Task<UpdateOrderResponse> UpdateAsync(UpdateOrderRequest request)
    {
        var entity = await _context.Orders.FindAsync(request.Id);

        if (entity == null)
            throw new Exception("Order not found");

        entity.Status = request.Status;

        await _context.SaveChangesAsync();

        return new UpdateOrderResponse
        {
            Id = entity.Id
        };
    }

    public async Task<DeleteOrderResponse> DeleteAsync(DeleteOrderRequest request)
    {
        var entity = await _context.Orders.FindAsync(request.Id);

        if (entity == null)
            return new DeleteOrderResponse { Success = false };

        _context.Orders.Remove(entity);
        await _context.SaveChangesAsync();

        return new DeleteOrderResponse { Success = true };
    }

    private async Task<int> GenerateOrderNumberAsync()
    {
        var last = await _context.Orders
            .OrderByDescending(o => o.OrderNumber)
            .FirstOrDefaultAsync();

        return last == null ? 1 : last.OrderNumber + 1;
    }
}
