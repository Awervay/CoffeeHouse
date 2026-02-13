using Microsoft.AspNetCore.Mvc;
using Service.Branches.Interfaces;
using Contract.Branches.Models.CoffeeChain;

namespace API.Gateway.Controllers.Controller.Branches;

[ApiController]
[Route("api/[controller]")]
public class CoffeeChainController : ControllerBase
{
    private readonly ICoffeeChainService _service;

    public CoffeeChainController(ICoffeeChainService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCoffeeChainResponse>> Get(Guid id)
    {
        var result = await _service.GetAsync(new GetCoffeeChainRequest { Id = id });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCoffeeChainsResponse>>> GetAll()
    {
        var result = await _service.GetAllAsync(new GetCoffeeChainsRequest());
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CreateCoffeeChainResponse>> Create(CreateCoffeeChainRequest request)
    {
        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateCoffeeChainResponse>> Update(Guid id, UpdateCoffeeChainRequest request)
    {
        request.Id = id;

        var result = await _service.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(new DeleteCoffeeChainRequest { Id = id });

        if (!result.Success)
            return NotFound();

        return NoContent();
    }
}
