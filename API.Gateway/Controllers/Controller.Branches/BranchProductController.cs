using Microsoft.AspNetCore.Mvc;
using Service.Branches.Interfaces;
using Contract.Branches.Models.BranchProduct;

namespace API.Gateway.Controllers.Controller.Branches;

[ApiController]
[Route("api/[controller]")]
public class BranchProductController : ControllerBase
{
    private readonly IBranchProductService _service;

    public BranchProductController(IBranchProductService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetBranchProductResponse>> Get(Guid id)
    {
        var result = await _service.GetAsync(new GetBranchProductRequest { Id = id });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetBranchProductsResponse>>> GetAll(
        [FromQuery] Guid? branchId,
        [FromQuery] bool? onlyAvailable)
    {
        var result = await _service.GetAllAsync(new GetBranchProductsRequest
        {
            BranchId = branchId,
            OnlyAvailable = onlyAvailable
        });

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CreateBranchProductResponse>> Create(CreateBranchProductRequest request)
    {
        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateBranchProductResponse>> Update(Guid id, UpdateBranchProductRequest request)
    {
        request.Id = id;

        var result = await _service.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(new DeleteBranchProductRequest { Id = id });

        if (!result.Success)
            return NotFound();

        return NoContent();
    }
}
