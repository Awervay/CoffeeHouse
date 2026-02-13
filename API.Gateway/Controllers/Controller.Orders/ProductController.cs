using Microsoft.AspNetCore.Mvc;
using Service.Orders.Interfaces;
using Contract.Orders.Models.Product;

namespace API.Gateway.Controllers.Controller.Orders;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetProductResponse>> Get(Guid id)
    {
        var result = await _service.GetAsync(new GetProductRequest { Id = id });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetProductsResponse>>> GetAll(
        [FromQuery] string? category)
    {
        var result = await _service.GetAllAsync(new GetProductsRequest
        {
            Category = category
        });

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CreateProductResponse>> Create(CreateProductRequest request)
    {
        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateProductResponse>> Update(Guid id, UpdateProductRequest request)
    {
        request.Id = id;

        var result = await _service.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(new DeleteProductRequest { Id = id });

        if (!result.Success)
            return NotFound();

        return NoContent();
    }
}
