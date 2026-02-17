using Contract.Staff.Models.Position;
using Core.DAL.Staff;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service.Staff.Interfaces;

namespace Service.Staff.Implementations;

public class PositionService : IPositionService
{
    private readonly AppDbContext _context;

    public PositionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetPositionResponse?> GetAsync(GetPositionRequest request)
    {
        var entity = await _context.Positions.FindAsync(request.Id);

        if (entity == null)
            return null;

        return new GetPositionResponse
        {
            Id = entity.Id,
            Title = entity.Title
        };
    }

    public async Task<IEnumerable<GetPositionsResponse>> GetAllAsync(GetPositionsRequest request)
    {
        var list = await _context.Positions.ToListAsync();

        return list.Select(p => new GetPositionsResponse
        {
            Id = p.Id,
            Title = p.Title
        });
    }

    public async Task<CreatePositionResponse> CreateAsync(CreatePositionRequest request)
    {
        var entity = new Position
        {
            Title = request.Title
        };

        _context.Positions.Add(entity);
        await _context.SaveChangesAsync();

        return new CreatePositionResponse
        {
            Id = entity.Id
        };
    }

    public async Task<UpdatePositionResponse> UpdateAsync(UpdatePositionRequest request)
    {
        var entity = await _context.Positions.FindAsync(request.Id);

        if (entity == null)
            throw new Exception("Position not found");

        entity.Title = request.Title;

        await _context.SaveChangesAsync();

        return new UpdatePositionResponse
        {
            Id = entity.Id
        };
    }

    public async Task<DeletePositionResponse> DeleteAsync(DeletePositionRequest request)
    {
        var entity = await _context.Positions.FindAsync(request.Id);

        if (entity == null)
            return new DeletePositionResponse { Success = false };

        _context.Positions.Remove(entity);
        await _context.SaveChangesAsync();

        return new DeletePositionResponse { Success = true };
    }
}
