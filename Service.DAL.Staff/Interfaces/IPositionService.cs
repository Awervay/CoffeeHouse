using Contract.Staff.Models.Position;

namespace Service.Staff.Interfaces;

public interface IPositionService
{
    Task<GetPositionResponse?> GetAsync(GetPositionRequest request);
    Task<IEnumerable<GetPositionsResponse>> GetAllAsync(GetPositionsRequest request);
    Task<CreatePositionResponse> CreateAsync(CreatePositionRequest request);
    Task<UpdatePositionResponse> UpdateAsync(UpdatePositionRequest request);
    Task<DeletePositionResponse> DeleteAsync(DeletePositionRequest request);
}
