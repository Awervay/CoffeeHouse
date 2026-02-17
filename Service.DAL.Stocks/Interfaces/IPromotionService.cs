using Contract.Stocks.Models.Promotion;

namespace Service.Stocks.Interfaces;

public interface IPromotionService
{
    Task<GetPromotionResponse?> GetAsync(GetPromotionRequest request);
    Task<IEnumerable<GetPromotionsResponse>> GetAllAsync(GetPromotionsRequest request);
    Task<CreatePromotionResponse> CreateAsync(CreatePromotionRequest request);
    Task<UpdatePromotionResponse> UpdateAsync(UpdatePromotionRequest request);
    Task<DeletePromotionResponse> DeleteAsync(DeletePromotionRequest request);
}
