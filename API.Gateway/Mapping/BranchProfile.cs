using AutoMapper;
using Core.DAL.Branches;
using Contract.Branches.Models.Branch;

public class BranchProfile : Profile
{
    public BranchProfile()
    {
        CreateMap<CreateBranchRequest, Branch>();
        CreateMap<UpdateBranchRequest, Branch>();

        CreateMap<Branch, GetBranchResponse>();
        CreateMap<Branch, GetBranchesResponse>();
        CreateMap<Branch, CreateBranchResponse>();
        CreateMap<Branch, UpdateBranchResponse>();
    }
}
