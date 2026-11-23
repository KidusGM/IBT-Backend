using Microsoft.AspNetCore.Mvc;

namespace AddisEats_Day_5_RestaurantService.Controllers;

[ApiController]
[Route("api/v1/test")]
public class TestExceptionController : ControllerBase
{
    [HttpGet("throw")]
    public IActionResult Throw()
    {
        throw new InvalidOperationException("Deliberate exception for Exercise 7.");
    }
}
