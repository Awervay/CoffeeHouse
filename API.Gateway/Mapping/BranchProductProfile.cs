using AutoMapper;
using Core.DAL.Branches;
using Contract.Branches.Models.BranchProduct;

public class BranchProductProfile : Profile
{
    public BranchProductProfile()
    {
        CreateMap<CreateBranchProductRequest, BranchProduct>();
        CreateMap<UpdateBranchProductRequest, BranchProduct>();

        CreateMap<BranchProduct, GetBranchProductResponse>();
        CreateMap<BranchProduct, GetBranchProductsResponse>();
        CreateMap<BranchProduct, CreateBranchProductResponse>();
        CreateMap<BranchProduct, UpdateBranchProductResponse>();
    }
}
