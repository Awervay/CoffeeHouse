using Contract.Branches.Models.Branch;
using Core.DAL.Branches;
using Data.DbContext;
using Service.Branches.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Service.Branches.Implementations;

public class BranchService : IBranchService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BranchService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetBranchResponse?> GetAsync(GetBranchRequest request)
    {
        var entity = await _context.Branches.FindAsync(request.Id);
        return entity == null ? null : _mapper.Map<GetBranchResponse>(entity);
    }

    public async Task<IEnumerable<GetBranchesResponse>> GetAllAsync(GetBranchesRequest request)
    {
        var branches = await _context.Branches.ToListAsync();
        return _mapper.Map<IEnumerable<GetBranchesResponse>>(branches);
    }

    public async Task<CreateBranchResponse> CreateAsync(CreateBranchRequest request)
    {
        var entity = _mapper.Map<Branch>(request);

        _context.Branches.Add(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<CreateBranchResponse>(entity);
    }

    public async Task<UpdateBranchResponse> UpdateAsync(Guid id, UpdateBranchRequest request)
    {
        var entity = await _context.Branches.FindAsync(id);
        if (entity == null)
            throw new Exception("Branch not found");

        _mapper.Map(request, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<UpdateBranchResponse>(entity);
    }

    public async Task<DeleteBranchResponse> DeleteAsync(DeleteBranchRequest request)
    {
        var entity = await _context.Branches.FindAsync(request.Id);

        if (entity == null)
            return new DeleteBranchResponse { Success = false };

        _context.Branches.Remove(entity);
        await _context.SaveChangesAsync();

        return new DeleteBranchResponse { Success = true };
    }
}
