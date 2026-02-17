using Microsoft.AspNetCore.Mvc;
using Service.Staff.Interfaces;
using Contract.Staff.Models.Employee;

namespace API.Gateway.Controllers.Controller.Staff;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetEmployeeResponse>> Get(Guid id)
    {
        var result = await _service.GetAsync(new GetEmployeeRequest { Id = id });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetEmployeesResponse>>> GetAll(
        [FromQuery] Guid? branchId,
        [FromQuery] Guid? positionId)
    {
        var result = await _service.GetAllAsync(new GetEmployeesRequest
        {
            BranchId = branchId,
            PositionId = positionId
        });

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CreateEmployeeResponse>> Create(CreateEmployeeRequest request)
    {
        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateEmployeeResponse>> Update(Guid id, UpdateEmployeeRequest request)
    {
        request.Id = id;

        var result = await _service.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(new DeleteEmployeeRequest { Id = id });

        if (!result.Success)
            return NotFound();

        return NoContent();
    }
}
