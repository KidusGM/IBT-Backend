using AddisEats_Day_4_ClassExercises.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats_Day_4_ClassExercises.Controllers
{
    [ApiController]
    [Route("api/v1/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("{amount}")]
        public IActionResult Pay(decimal amount)
        {
            return Ok(new
            {
                Message = _paymentService.MakePayment(amount)
            });
        }
    }
}