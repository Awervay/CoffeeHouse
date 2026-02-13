using Microsoft.AspNetCore.Mvc;
using Service.Stocks.Interfaces;
using Contract.Stocks.Models.Promotion;

namespace API.Gateway.Controllers.Controller.Stocks;

[ApiController]
[Route("api/[controller]")]
public class PromotionController : ControllerBase
{
    private readonly IPromotionService _service;

    public PromotionController(IPromotionService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetPromotionResponse>> Get(Guid id)
    {
        var result = await _service.GetAsync(new GetPromotionRequest { Id = id });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetPromotionsResponse>>> GetAll(
        [FromQuery] Guid? branchId,
        [FromQuery] DateTime? activeOnDate)
    {
        var result = await _service.GetAllAsync(new GetPromotionsRequest
        {
            BranchId = branchId,
            ActiveOnDate = activeOnDate
        });

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CreatePromotionResponse>> Create(CreatePromotionRequest request)
    {
        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdatePromotionResponse>> Update(Guid id, UpdatePromotionRequest request)
    {
        request.Id = id;

        var result = await _service.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(new DeletePromotionRequest { Id = id });

        if (!result.Success)
            return NotFound();

        return NoContent();
    }
}
