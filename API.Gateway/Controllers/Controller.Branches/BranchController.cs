using Microsoft.AspNetCore.Mvc;
using Service.Branches.Interfaces;
using Contract.Branches.Models.Branch;

namespace API.Gateway.Controllers.Controller.Branches;

[ApiController]
[Route("api/[controller]")]
public class BranchController : ControllerBase
{
    private readonly IBranchService _service;

    public BranchController(IBranchService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetBranchResponse>> Get(Guid id)
    {
        var result = await _service.GetAsync(new GetBranchRequest { Id = id });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetBranchesResponse>>> GetAll()
    {
        var result = await _service.GetAllAsync(new GetBranchesRequest());
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CreateBranchResponse>> Create(CreateBranchRequest request)
    {
        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateBranchResponse>> Update(Guid id, UpdateBranchRequest request)
    {
        request.Id = id;

        var result = await _service.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(new DeleteBranchRequest { Id = id });

        if (!result.Success)
            return NotFound();

        return NoContent();
    }
}
