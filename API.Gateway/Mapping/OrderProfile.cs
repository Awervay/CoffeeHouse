using AutoMapper;
using Core.DAL.Orders;
using Contract.Orders.Models.Order;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<CreateOrderRequest, Order>();
        CreateMap<UpdateOrderRequest, Order>();

        CreateMap<Order, GetOrderResponse>();
        CreateMap<Order, GetOrdersResponse>();
        CreateMap<Order, CreateOrderResponse>();
        CreateMap<Order, UpdateOrderResponse>();

        CreateMap<Order, OrderModel>();
    }
}
