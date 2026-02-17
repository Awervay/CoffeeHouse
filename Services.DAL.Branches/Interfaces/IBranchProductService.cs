using Contract.Branches.Models.BranchProduct;

namespace Service.Branches.Interfaces;

public interface IBranchProductService
{
    Task<GetBranchProductResponse?> GetAsync(GetBranchProductRequest request);
    Task<IEnumerable<GetBranchProductsResponse>> GetAllAsync(GetBranchProductsRequest request);
    Task<CreateBranchProductResponse> CreateAsync(CreateBranchProductRequest request);
    Task<UpdateBranchProductResponse> UpdateAsync(UpdateBranchProductRequest request);
    Task<DeleteBranchProductResponse> DeleteAsync(DeleteBranchProductRequest request);
}
