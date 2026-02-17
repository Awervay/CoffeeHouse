using Contract.Branches.Models.Branch;
using Core.DAL.Branches;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service.Branches.Interfaces;

namespace Service.Branches.Implementations;

public class BranchService : IBranchService
{
    private readonly AppDbContext _context;

    public BranchService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetBranchResponse?> GetAsync(GetBranchRequest request)
    {
        var entity = await _context.Branches.FindAsync(request.Id);

        if (entity == null)
            return null;

        return new GetBranchResponse
        {
            Id = entity.Id,
            City = entity.City,
            Country = entity.Country,
            Address = entity.Address,
            CoffeeChainId = entity.CoffeeChainId
        };
    }

    public async Task<IEnumerable<GetBranchesResponse>> GetAllAsync(GetBranchesRequest request)
    {
        var branches = await _context.Branches.ToListAsync();

        return branches.Select(b => new GetBranchesResponse
        {
            Id = b.Id,
            City = b.City,
            Country = b.Country
        });
    }

    public async Task<CreateBranchResponse> CreateAsync(CreateBranchRequest request)
    {
        var entity = new Branch
        {
            City = request.City,
            Country = request.Country,
            Address = request.Address,
            CoffeeChainId = request.CoffeeChainId
        };

        _context.Branches.Add(entity);
        await _context.SaveChangesAsync();

        return new CreateBranchResponse
        {
            Id = entity.Id,
            City = entity.City
        };
    }

    public async Task<UpdateBranchResponse> UpdateAsync(UpdateBranchRequest request)
    {
        var entity = await _context.Branches.FindAsync(request.Id);

        if (entity == null)
            throw new Exception("Branch not found");

        entity.City = request.City;
        entity.Country = request.Country;
        entity.Address = request.Address;
        entity.CoffeeChainId = request.CoffeeChainId;

        await _context.SaveChangesAsync();

        return new UpdateBranchResponse
        {
            Id = entity.Id,
            City = entity.City
        };
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
