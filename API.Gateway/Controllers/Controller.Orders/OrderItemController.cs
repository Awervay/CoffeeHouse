using Microsoft.AspNetCore.Mvc;
using Service.Orders.Interfaces;
using Contract.Orders.Models.OrderItem;

namespace API.Gateway.Controllers.Controller.Orders;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController : ControllerBase
{
    private readonly IOrderItemService _service;

    public OrderItemController(IOrderItemService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetOrderItemResponse>> Get(Guid id)
    {
        var result = await _service.GetAsync(new GetOrderItemRequest { Id = id });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetOrderItemsResponse>>> GetAll(
        [FromQuery] Guid? orderId)
    {
        var result = await _service.GetAllAsync(new GetOrderItemsRequest
        {
            OrderId = orderId
        });

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CreateOrderItemResponse>> Create(CreateOrderItemRequest request)
    {
        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateOrderItemResponse>> Update(Guid id, UpdateOrderItemRequest request)
    {
        request.Id = id;

        var result = await _service.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(new DeleteOrderItemRequest { Id = id });

        if (!result.Success)
            return NotFound();

        return NoContent();
    }
}
