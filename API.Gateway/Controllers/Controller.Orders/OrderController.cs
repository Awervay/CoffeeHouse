using Microsoft.AspNetCore.Mvc;
using Service.Orders.Interfaces;
using Contract.Orders.Models.Order;

namespace API.Gateway.Controllers.Controller.Orders;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetOrderResponse>> Get(Guid id)
    {
        var result = await _service.GetAsync(new GetOrderRequest { Id = id });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetOrdersResponse>>> GetAll(
        [FromQuery] Guid? branchId,
        [FromQuery] int? status)
    {
        var result = await _service.GetAllAsync(new GetOrdersRequest
        {
            BranchId = branchId,
            Status = status
        });

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CreateOrderResponse>> Create(CreateOrderRequest request)
    {
        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateOrderResponse>> Update(Guid id, UpdateOrderRequest request)
    {
        request.Id = id;

        var result = await _service.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(new DeleteOrderRequest { Id = id });

        if (!result.Success)
            return NotFound();

        return NoContent();
    }
}
