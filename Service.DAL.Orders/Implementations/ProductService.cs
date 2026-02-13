using Contract.Orders.Models.Product;
using Core.DAL.Orders;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service.Orders.Interfaces;

namespace Service.Orders.Implementations;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetProductResponse?> GetAsync(GetProductRequest request)
    {
        var entity = await _context.Products.FindAsync(request.Id);

        if (entity == null)
            return null;

        return new GetProductResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Category = entity.Category
        };
    }

    public async Task<IEnumerable<GetProductsResponse>> GetAllAsync(GetProductsRequest request)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Category))
            query = query.Where(p => p.Category == request.Category);

        var list = await query.ToListAsync();

        return list.Select(p => new GetProductsResponse
        {
            Id = p.Id,
            Name = p.Name
        });
    }

    public async Task<CreateProductResponse> CreateAsync(CreateProductRequest request)
    {
        var entity = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Category = request.Category
        };

        _context.Products.Add(entity);
        await _context.SaveChangesAsync();

        return new CreateProductResponse
        {
            Id = entity.Id
        };
    }

    public async Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest request)
    {
        var entity = await _context.Products.FindAsync(request.Id);

        if (entity == null)
            throw new Exception("Product not found");

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Category = request.Category;

        await _context.SaveChangesAsync();

        return new UpdateProductResponse
        {
            Id = entity.Id
        };
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
