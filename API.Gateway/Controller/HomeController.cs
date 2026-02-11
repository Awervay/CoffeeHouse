using Microsoft.AspNetCore.Mvc;
using Orchestrator.Extensions;
using Services.Interfaces;

namespace API.Gateway.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBranchService _branchServices;
        public HomeController(IBranchService services) 
        {
            _branchServices = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranch()
        {
            try
            {
                var response = await _branchServices.GetAllAsync();
                return Ok(response);
            }
            catch(Exception ex)
            {
                return NotFound();
            }        
        }

    }
}
