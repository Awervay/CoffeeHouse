using AutoMapper;
using Contract.Stocks.Models.Promotion;
using Core.DAL.Stocks;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service.Stocks.Interfaces;

namespace Service.Stocks.Implementations;

public class PromotionService : IPromotionService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PromotionService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetPromotionResponse?> GetAsync(GetPromotionRequest request)
    {
        var entity = await _context.Promotions.FindAsync(request.Id);
        return entity == null ? null : _mapper.Map<GetPromotionResponse>(entity);
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
        return _mapper.Map<IEnumerable<GetPromotionsResponse>>(list);
    }

    public async Task<CreatePromotionResponse> CreateAsync(CreatePromotionRequest request)
    {
        var entity = _mapper.Map<Promotion>(request);

        _context.Promotions.Add(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<CreatePromotionResponse>(entity);
    }

    public async Task<UpdatePromotionResponse> UpdateAsync(Guid id, UpdatePromotionRequest request)
    {
        var entity = await _context.Promotions.FindAsync(id);
        if (entity == null)
            throw new Exception("Promotion not found");

        _mapper.Map(request, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<UpdatePromotionResponse>(entity);
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
