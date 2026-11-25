using AddisEatsNew.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AddisEatsNew.Api.Controllers;

[ApiController]
[Route("api/audit-demo")]
[ServiceFilter(typeof(ActionAuditFilter))]
public sealed class AuditDemoController : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult Get(int id, [FromQuery] string? note)
        => Ok(new { id, note });
}
