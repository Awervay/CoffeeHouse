using AutoMapper;
using Core.DAL.Staff;
using Contract.Staff.Models.Position;

public class PositionProfile : Profile
{
    public PositionProfile()
    {
        CreateMap<CreatePositionRequest, Position>();
        CreateMap<UpdatePositionRequest, Position>();

        CreateMap<Position, GetPositionResponse>();
        CreateMap<Position, GetPositionsResponse>();
        CreateMap<Position, CreatePositionResponse>();
        CreateMap<Position, UpdatePositionResponse>();
    }
}
