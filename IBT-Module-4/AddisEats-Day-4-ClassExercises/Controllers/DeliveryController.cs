using AddisEats_Day_4_ClassExercises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AddisEats_Day_4_ClassExercises.Controllers
{
    [ApiController]
    [Route("api/v1/delivery")]
    public class DeliveryController : ControllerBase
    {
        private readonly DeliveryOptions _options;

        public DeliveryController(IOptions<DeliveryOptions> options)
        {
            _options = options.Value;
        }

        [HttpGet("options")]
        public IActionResult GetOptions()
        {
            return Ok(new
            {
                _options.FreeAboveEtb,
                _options.DefaultFeeEtb
            });
        }
    }
}