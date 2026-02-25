using AutoMapper;
using Contract.Orders.Models.OrderItem;
using Core.DAL.Orders;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service.Orders.Interfaces;

namespace Service.Orders.Implementations;

public class OrderItemService : IOrderItemService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public OrderItemService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetOrderItemResponse?> GetAsync(GetOrderItemRequest request)
    {
        var entity = await _context.OrderItems.FindAsync(request.Id);
        return entity == null ? null : _mapper.Map<GetOrderItemResponse>(entity);
    }

    public async Task<IEnumerable<GetOrderItemsResponse>> GetAllAsync(GetOrderItemsRequest request)
    {
        var query = _context.OrderItems.AsQueryable();

        if (request.OrderId.HasValue)
            query = query.Where(i => i.OrderId == request.OrderId.Value);

        var list = await query.ToListAsync();
        return _mapper.Map<IEnumerable<GetOrderItemsResponse>>(list);
    }

    public async Task<CreateOrderItemResponse> CreateAsync(CreateOrderItemRequest request)
    {
        var entity = _mapper.Map<OrderItem>(request);

        _context.OrderItems.Add(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<CreateOrderItemResponse>(entity);
    }

    public async Task<UpdateOrderItemResponse> UpdateAsync(Guid id, UpdateOrderItemRequest request)
    {
        var entity = await _context.OrderItems.FindAsync(id);
        if (entity == null)
            throw new Exception("Order item not found");

        _mapper.Map(request, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<UpdateOrderItemResponse>(entity);
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
