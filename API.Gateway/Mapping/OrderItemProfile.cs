using AutoMapper;
using Core.DAL.Orders;
using Contract.Orders.Models.OrderItem;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<CreateOrderItemRequest, OrderItem>();
        CreateMap<UpdateOrderItemRequest, OrderItem>();

        CreateMap<OrderItem, GetOrderItemResponse>();
        CreateMap<OrderItem, GetOrderItemsResponse>();
        CreateMap<OrderItem, CreateOrderItemResponse>();
        CreateMap<OrderItem, UpdateOrderItemResponse>();
    }
}
