using AddisEats_Day_4_ClassExercises.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats_Day_4_ClassExercises.Controllers
{
    [ApiController]
    [Route("api/v1/health")]
    public class HealthController : ControllerBase
    {
        private readonly IClock _clock;
        private readonly IClock _secondClock;
        private readonly IWebHostEnvironment _environment;

        public HealthController(
            IClock clock,
            IClock secondClock,
            IWebHostEnvironment environment)
        {
            _clock = clock;
            _secondClock = secondClock;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok(new
            {
                UtcTime = _clock.UtcNow,
                Environment = _environment.EnvironmentName,
                FirstClockCreated = _clock.CreatedAtUtc,
                SecondClockCreated = _secondClock.CreatedAtUtc
            });
        }
    }
}