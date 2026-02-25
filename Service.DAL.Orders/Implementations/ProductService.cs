using AutoMapper;
using Contract.Orders.Models.Product;
using Core.DAL.Orders;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service.Orders.Interfaces;

namespace Service.Orders.Implementations;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProductService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetProductResponse?> GetAsync(GetProductRequest request)
    {
        var entity = await _context.Products.FindAsync(request.Id);
        return entity == null ? null : _mapper.Map<GetProductResponse>(entity);
    }

    public async Task<IEnumerable<GetProductsResponse>> GetAllAsync(GetProductsRequest request)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Category))
            query = query.Where(p => p.Category == request.Category);

        var list = await query.ToListAsync();
        return _mapper.Map<IEnumerable<GetProductsResponse>>(list);
    }

    public async Task<CreateProductResponse> CreateAsync(CreateProductRequest request)
    {
        var entity = _mapper.Map<Product>(request);

        _context.Products.Add(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<CreateProductResponse>(entity);
    }

    public async Task<UpdateProductResponse> UpdateAsync(Guid id, UpdateProductRequest request)
    {
        var entity = await _context.Products.FindAsync(id);
        if (entity == null)
            throw new Exception("Product not found");

        _mapper.Map(request, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<UpdateProductResponse>(entity);
    }

    public async Task<DeleteProductResponse> DeleteAsync(DeleteProductRequest request)
    {
        var entity = await _context.Products.FindAsync(request.Id);

        if (entity == null)
            return new DeleteProductResponse { Success = false };

        _context.Products.Remove(entity);
        await _context.SaveChangesAsync();

        return new DeleteProductResponse { Success = true };
    }
}
