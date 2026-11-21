using AddisEatsNew.Api.DTOs;
using AddisEatsNew.Api.Models;
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
            var order = _orderServices.CreateOrder(createDTO);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
           // return Ok(order);
        }
    }
}
