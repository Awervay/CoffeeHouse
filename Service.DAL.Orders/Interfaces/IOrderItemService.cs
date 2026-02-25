using Contract.Orders.Models.OrderItem;

namespace Service.Orders.Interfaces;

public interface IOrderItemService
{
    Task<GetOrderItemResponse?> GetAsync(GetOrderItemRequest request);
    Task<IEnumerable<GetOrderItemsResponse>> GetAllAsync(GetOrderItemsRequest request);
    Task<CreateOrderItemResponse> CreateAsync(CreateOrderItemRequest request);
    Task<UpdateOrderItemResponse> UpdateAsync(Guid id, UpdateOrderItemRequest request);
    Task<DeleteOrderItemResponse> DeleteAsync(DeleteOrderItemRequest request);
}
