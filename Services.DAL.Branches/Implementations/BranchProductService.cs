using Contract.Branches.Models.BranchProduct;
using Core.DAL.Branches;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service.Branches.Interfaces;

namespace Service.Branches.Implementations;

public class BranchProductService : IBranchProductService
{
    private readonly AppDbContext _context;

    public BranchProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetBranchProductResponse?> GetAsync(GetBranchProductRequest request)
    {
        var entity = await _context.BranchProducts.FindAsync(request.Id);

        if (entity == null)
            return null;

        return new GetBranchProductResponse
        {
            Id = entity.Id,
            BranchId = entity.BranchId,
            ProductId = entity.ProductId,
            Price = entity.Price,
            IsAvailable = entity.IsAvailable
        };
    }

    public async Task<IEnumerable<GetBranchProductsResponse>> GetAllAsync(GetBranchProductsRequest request)
    {
        var query = _context.BranchProducts.AsQueryable();

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId.Value);

        if (request.OnlyAvailable == true)
            query = query.Where(x => x.IsAvailable);

        var list = await query.ToListAsync();

        return list.Select(x => new GetBranchProductsResponse
        {
            Id = x.Id,
            ProductId = x.ProductId,
            Price = x.Price,
            IsAvailable = x.IsAvailable
        });
    }

    public async Task<CreateBranchProductResponse> CreateAsync(CreateBranchProductRequest request)
    {
        var entity = new BranchProduct
        {
            BranchId = request.BranchId,
            ProductId = request.ProductId,
            Price = request.Price,
            IsAvailable = request.IsAvailable
        };

        _context.BranchProducts.Add(entity);
        await _context.SaveChangesAsync();

        return new CreateBranchProductResponse
        {
            Id = entity.Id
        };
    }

    public async Task<UpdateBranchProductResponse> UpdateAsync(UpdateBranchProductRequest request)
    {
        var entity = await _context.BranchProducts.FindAsync(request.Id);

        if (entity == null)
            throw new Exception("Branch product not found");

        entity.Price = request.Price;
        entity.IsAvailable = request.IsAvailable;

        await _context.SaveChangesAsync();

        return new UpdateBranchProductResponse
        {
            Id = entity.Id
        };
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
