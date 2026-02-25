using AutoMapper;
using Core.DAL.Stocks;
using Contract.Stocks.Models.Promotion;

public class PromotionProfile : Profile
{
    public PromotionProfile()
    {
        CreateMap<CreatePromotionRequest, Promotion>();
        CreateMap<UpdatePromotionRequest, Promotion>();

        CreateMap<Promotion, GetPromotionResponse>();
        CreateMap<Promotion, GetPromotionsResponse>();
        CreateMap<Promotion, CreatePromotionResponse>();
        CreateMap<Promotion, UpdatePromotionResponse>();
    }
}
