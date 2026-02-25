using AutoMapper;
using Contract.Staff.Models.Position;
using Core.DAL.Staff;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service.Staff.Interfaces;

namespace Service.Staff.Implementations;

public class PositionService : IPositionService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PositionService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetPositionResponse?> GetAsync(GetPositionRequest request)
    {
        var entity = await _context.Positions.FindAsync(request.Id);
        return entity == null ? null : _mapper.Map<GetPositionResponse>(entity);
    }

    public async Task<IEnumerable<GetPositionsResponse>> GetAllAsync(GetPositionsRequest request)
    {
        var list = await _context.Positions.ToListAsync();
        return _mapper.Map<IEnumerable<GetPositionsResponse>>(list);
    }

    public async Task<CreatePositionResponse> CreateAsync(CreatePositionRequest request)
    {
        var entity = _mapper.Map<Position>(request);

        _context.Positions.Add(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<CreatePositionResponse>(entity);
    }

    public async Task<UpdatePositionResponse> UpdateAsync(Guid id, UpdatePositionRequest request)
    {
        var entity = await _context.Positions.FindAsync(id);
        if (entity == null)
            throw new Exception("Position not found");

        _mapper.Map(request, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<UpdatePositionResponse>(entity);
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
