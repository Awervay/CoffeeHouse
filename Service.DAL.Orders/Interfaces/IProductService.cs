using Contract.Orders.Models.Product;

namespace Service.Orders.Interfaces;

public interface IProductService
{
    Task<GetProductResponse?> GetAsync(GetProductRequest request);
    Task<IEnumerable<GetProductsResponse>> GetAllAsync(GetProductsRequest request);
    Task<CreateProductResponse> CreateAsync(CreateProductRequest request);
    Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest request);
    Task<DeleteProductResponse> DeleteAsync(DeleteProductRequest request);
}
