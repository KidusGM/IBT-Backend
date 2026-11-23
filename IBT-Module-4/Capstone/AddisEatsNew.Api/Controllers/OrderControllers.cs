using AddisEatsNew.Api.DTOs;
using AddisEatsNew.Api.Models;
using AddisEatsNew.Api.Common;
using Microsoft.AspNetCore.Mvc;
using AddisEatsNew.Api.Services.OrderServices;
namespace AddisEatsNew.Api.Controllers
{

    [ApiController]
    [Route("Api/[controller]")]
    public class OrderControllers  : ControllerBase
    {
        private  IOrderServices _orderServices;

        public OrderControllers(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _orderServices.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost()]
        public IActionResult CreateOrder([FromBody] CreateOrderDTO createDTO)
        {

            var result = _orderServices.CreateOrder(createDTO);
            if (!result.IsSuccess)
            {
                return Problem(
                    title: result.Error?.Message,
                    statusCode: result.Error?.Status,
                    detail: result.Error?.Code
                    );
            }
            var order = result.Value;

            return CreatedAtAction(
                nameof(GetById),
                new { id = order.Id },
                order
                );
            //var order = _orderServices.CreateOrder(createDTO);
           // return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
           // return Ok(order);
        }
    }
}
