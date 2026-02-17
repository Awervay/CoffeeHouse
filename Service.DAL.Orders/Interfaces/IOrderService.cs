using Contract.Orders.Models.Order;

namespace Service.Orders.Interfaces;

public interface IOrderService
{
    Task<GetOrderResponse?> GetAsync(GetOrderRequest request);
    Task<IEnumerable<GetOrdersResponse>> GetAllAsync(GetOrdersRequest request);
    Task<CreateOrderResponse> CreateAsync(CreateOrderRequest request);
    Task<UpdateOrderResponse> UpdateAsync(UpdateOrderRequest request);
    Task<DeleteOrderResponse> DeleteAsync(DeleteOrderRequest request);
}
