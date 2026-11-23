using AddisEats_Day_5_RestaurantService.Models;
using AddisEats_Day_5_RestaurantService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats_Day_5_RestaurantService.Controllers;

[ApiController]
[Route("api/v1/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public IActionResult PlaceOrder([FromBody] CreateOrderRequest request)
    {
        var result = _orderService.Place(request);

        if (!result.IsSuccess)
        {
            return BadRequest(new
            {
                Error = new
                {
                    result.Error!.Code,
                    result.Error.Message
                }
            });
        }

        return Ok(result.Value);
    }
}
