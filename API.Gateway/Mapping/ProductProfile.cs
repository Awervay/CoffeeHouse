using AutoMapper;
using Core.DAL.Orders;
using Contract.Orders.Models.Product;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductRequest, Product>();
        CreateMap<UpdateProductRequest, Product>();

        CreateMap<Product, GetProductResponse>();
        CreateMap<Product, GetProductsResponse>();
        CreateMap<Product, CreateProductResponse>();
        CreateMap<Product, UpdateProductResponse>();
    }
}
