using AutoMapper;
using Contract.Orders.Models.Order;
using Core.DAL.Orders.Enum;
using Core.DAL.Orders;
using Data.DbContext;
using Service.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.Orders.Implementations;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public OrderService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetOrderResponse?> GetAsync(GetOrderRequest request)
    {
        var entity = await _context.Orders.FindAsync(request.Id);
        return entity == null ? null : _mapper.Map<GetOrderResponse>(entity);
    }

    public async Task<IEnumerable<GetOrdersResponse>> GetAllAsync(GetOrdersRequest request)
    {
        var query = _context.Orders.AsQueryable();

        if (request.BranchId.HasValue)
            query = query.Where(o => o.BranchId == request.BranchId.Value);

        if (request.Status.HasValue)
            query = query.Where(o => o.Status == request.Status.Value);

        var list = await query.ToListAsync();
        return _mapper.Map<IEnumerable<GetOrdersResponse>>(list);
    }

    public async Task<CreateOrderResponse> CreateAsync(CreateOrderRequest request)
    {
        var entity = _mapper.Map<Order>(request);

        entity.OrderNumber = await GenerateOrderNumberAsync();
        entity.CreatedAt = DateTime.UtcNow;
        entity.Status = (int)OrderStatus.New;

        _context.Orders.Add(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<CreateOrderResponse>(entity);
    }

    public async Task<UpdateOrderResponse> UpdateAsync(Guid id, UpdateOrderRequest request)
    {
        var entity = await _context.Orders.FindAsync(id);
        if (entity == null)
            throw new Exception("Order not found");

        _mapper.Map(request, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<UpdateOrderResponse>(entity);
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
