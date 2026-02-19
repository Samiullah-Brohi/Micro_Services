using Microsoft.AspNetCore.Mvc;
using supportservices.Models;
using supportservices.Services;

namespace supportservices.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupportServicesController : ControllerBase
{
    private readonly ISupportServicesDataService _supportServicesDataService;

    public SupportServicesController(ISupportServicesDataService supportServicesDataService)
    {
        _supportServicesDataService = supportServicesDataService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupportServiceRecord>>> Get(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate,
        [FromQuery] int employeeId,
        CancellationToken cancellationToken)
    {
        if (endDate < startDate)
        {
            return BadRequest("endDate must be greater than or equal to startDate.");
        }

        var results = await _supportServicesDataService.GetEmployeeSupportDataAsync(
            startDate,
            endDate,
            employeeId,
            cancellationToken);
        return Ok(results);
    }
}
