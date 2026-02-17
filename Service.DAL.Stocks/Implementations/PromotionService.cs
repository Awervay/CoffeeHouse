using Contract.Stocks.Models.Promotion;
using Core.DAL.Stocks;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service.Stocks.Interfaces;

namespace Service.Stocks.Implementations;

public class PromotionService : IPromotionService
{
    private readonly AppDbContext _context;

    public PromotionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetPromotionResponse?> GetAsync(GetPromotionRequest request)
    {
        var entity = await _context.Promotions.FindAsync(request.Id);

        if (entity == null)
            return null;

        return new GetPromotionResponse
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            BranchId = entity.BranchId
        };
    }

    public async Task<IEnumerable<GetPromotionsResponse>> GetAllAsync(GetPromotionsRequest request)
    {
        var query = _context.Promotions.AsQueryable();

        if (request.BranchId.HasValue)
            query = query.Where(p => p.BranchId == request.BranchId.Value);

        if (request.ActiveOnDate.HasValue)
        {
            var date = request.ActiveOnDate.Value;
            query = query.Where(p => p.StartDate <= date && p.EndDate >= date);
        }

        var list = await query.ToListAsync();

        return list.Select(p => new GetPromotionsResponse
        {
            Id = p.Id,
            Title = p.Title
        });
    }

    public async Task<CreatePromotionResponse> CreateAsync(CreatePromotionRequest request)
    {
        var entity = new Promotion
        {
            Title = request.Title,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            BranchId = request.BranchId
        };

        _context.Promotions.Add(entity);
        await _context.SaveChangesAsync();

        return new CreatePromotionResponse
        {
            Id = entity.Id
        };
    }

    public async Task<UpdatePromotionResponse> UpdateAsync(UpdatePromotionRequest request)
    {
        var entity = await _context.Promotions.FindAsync(request.Id);

        if (entity == null)
            throw new Exception("Promotion not found");

        entity.Title = request.Title;
        entity.Description = request.Description;
        entity.StartDate = request.StartDate;
        entity.EndDate = request.EndDate;
        entity.BranchId = request.BranchId;

        await _context.SaveChangesAsync();

        return new UpdatePromotionResponse
        {
            Id = entity.Id
        };
    }

    public async Task<DeletePromotionResponse> DeleteAsync(DeletePromotionRequest request)
    {
        var entity = await _context.Promotions.FindAsync(request.Id);

        if (entity == null)
            return new DeletePromotionResponse { Success = false };

        _context.Promotions.Remove(entity);
        await _context.SaveChangesAsync();

        return new DeletePromotionResponse { Success = true };
    }
}
