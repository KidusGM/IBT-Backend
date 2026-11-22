using AddisEats_Day_3_MenuServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats_Day_3_MenuServices.Controllers

{

    [ApiController]
    [Route("api/v1/exercises")]
    public class ExercisesController : ControllerBase
    {
        private readonly DescriptionService _descriptionService;
        private readonly ModelDemoService _modelDemoService;
        private readonly OrderService _orderService;
        private readonly DiscountService _discountService;
        private readonly AmountValidationService _amountValidationService;

        public ExercisesController(
            DescriptionService descriptionService,
            ModelDemoService modelDemoService,
            OrderService orderService,
            DiscountService discountService,
            AmountValidationService amountValidationService)
        {
            _descriptionService = descriptionService;
            _modelDemoService = modelDemoService;
            _orderService = orderService;
            _discountService = discountService;
            _amountValidationService = amountValidationService;
        }

        [HttpGet("overloads")]
        public IActionResult Overloads()
        {
            return Ok(new
            {
                Integer = _descriptionService.Describe(10),
                Text = _descriptionService.Describe("Doro Wot"),
                Decimal = _descriptionService.Describe(148.50m)
            });
        }

        [HttpGet("restaurants")]
        public IActionResult RestaurantDemo()
        {
            return Ok(_modelDemoService.RestaurantDemo());
        }

        [HttpGet("customers")]
        public IActionResult CustomerDemo()
        {
            return Ok(_modelDemoService.CustomerDemo());
        }

        [HttpGet("orders/bole")]
        public IActionResult BoleOrders()
        {
            return Ok(_orderService.GetBoleOrdersOver500());
        }

        [HttpGet("orders/customer-names")]
        public IActionResult CustomerNames()
        {
            return Ok(_orderService.GetCustomerNames());
        }

        [HttpGet("orders/kazanchis-revenue")]
        public IActionResult KazanchisRevenue()
        {
            return Ok(new
            {
                Revenue = _orderService.GetKazanchisRevenue()
            });
        }

        [HttpGet("orders/pages/{pageNumber:int}")]
        public IActionResult OrderPage(int pageNumber)
        {
            return Ok(_orderService.GetPage(pageNumber, 10));
        }
    }
}

