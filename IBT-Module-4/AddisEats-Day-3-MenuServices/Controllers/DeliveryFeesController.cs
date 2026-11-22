
//sing AddisEats_Day_3_MenuServices.Models;
using AddisEats_Day_3_MenuServices.Modeles;
using AddisEats_Day_3_MenuServices.Services;
using Microsoft.AspNetCore.Mvc;



namespace AddisEats_Day_3_MenuServices.Controllers;

public class DeliveryFeesController : ControllerBase
{
    private readonly DeliveryFeeService _service;

    public DeliveryFeesController(DeliveryFeeService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Calculate([FromBody] DeliveryFeeRequest request)
    {
        decimal fee = _service.DeliveryFee(
            request.Area,
            request.IsVip);

        return Ok(new
        {
            request.Area,
            request.IsVip,
            DeliveryFee = fee
        });
    }
}




