using AutoMapper;
using Contract.Branches.Models.BranchProduct;
using Core.DAL.Branches;
using Data.DbContext;
using Service.Branches.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.Branches.Implementations;

public class BranchProductService : IBranchProductService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BranchProductService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetBranchProductResponse?> GetAsync(GetBranchProductRequest request)
    {
        var entity = await _context.BranchProducts.FindAsync(request.Id);
        return entity == null ? null : _mapper.Map<GetBranchProductResponse>(entity);
    }

    public async Task<IEnumerable<GetBranchProductsResponse>> GetAllAsync(GetBranchProductsRequest request)
    {
        var query = _context.BranchProducts.AsQueryable();

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId.Value);

        if (request.OnlyAvailable == true)
            query = query.Where(x => x.IsAvailable);

        var list = await query.ToListAsync();
        return _mapper.Map<IEnumerable<GetBranchProductsResponse>>(list);
    }

    public async Task<CreateBranchProductResponse> CreateAsync(CreateBranchProductRequest request)
    {
        var entity = _mapper.Map<BranchProduct>(request);

        _context.BranchProducts.Add(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<CreateBranchProductResponse>(entity);
    }

    public async Task<UpdateBranchProductResponse> UpdateAsync(Guid id, UpdateBranchProductRequest request)
    {
        var entity = await _context.BranchProducts.FindAsync(id);
        if (entity == null)
            throw new Exception("Branch product not found");

        _mapper.Map(request, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<UpdateBranchProductResponse>(entity);
    }

    public async Task<DeleteBranchProductResponse> DeleteAsync(DeleteBranchProductRequest request)
    {
        var entity = await _context.BranchProducts.FindAsync(request.Id);

        if (entity == null)
            return new DeleteBranchProductResponse { Success = false };

        _context.BranchProducts.Remove(entity);
        await _context.SaveChangesAsync();

        return new DeleteBranchProductResponse { Success = true };
    }
}
