using Microsoft.AspNetCore.Mvc;
using Service.Staff.Interfaces;
using Contract.Staff.Models.Position;

namespace API.Gateway.Controllers.Controller.Staff;

[ApiController]
[Route("api/[controller]")]
public class PositionController : ControllerBase
{
    private readonly IPositionService _service;

    public PositionController(IPositionService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetPositionResponse>> Get(Guid id)
    {
        var result = await _service.GetAsync(new GetPositionRequest { Id = id });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetPositionsResponse>>> GetAll()
    {
        var result = await _service.GetAllAsync(new GetPositionsRequest());
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CreatePositionResponse>> Create(CreatePositionRequest request)
    {
        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdatePositionResponse>> Update(Guid id, UpdatePositionRequest request)
    {
        request.Id = id;

        var result = await _service.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(new DeletePositionRequest { Id = id });

        if (!result.Success)
            return NotFound();

        return NoContent();
    }
}
