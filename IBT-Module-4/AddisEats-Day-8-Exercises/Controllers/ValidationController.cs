using AddisEats_Day_5_RestaurantService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats_Day_5_RestaurantService.Controllers;

[ApiController]
[Route("api/v1/validation")]
public class ValidationController : ControllerBase
{
    [HttpPost("amount")]
    public IActionResult ValidateAmount([FromBody] AmountValidationRequest request)
    {
        return Ok(new { Message = "Amount is valid.", request.AmountEtb });
    }
}
