using Contract.Branches.Models.Branch;

namespace Service.Branches.Interfaces;

public interface IBranchService
{
    Task<GetBranchResponse?> GetAsync(GetBranchRequest request);
    Task<IEnumerable<GetBranchesResponse>> GetAllAsync(GetBranchesRequest request);
    Task<CreateBranchResponse> CreateAsync(CreateBranchRequest request);
    Task<UpdateBranchResponse> UpdateAsync(UpdateBranchRequest request);
    Task<DeleteBranchResponse> DeleteAsync(DeleteBranchRequest request);
}
