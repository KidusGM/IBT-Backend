using AddisEatsNew.Api.Services.MenuItemServices;
using AddisEatsNew.Api.Models;
using Microsoft.AspNetCore.Mvc;
//using System.ComponentModel;
//using System.Xml.Linq;

namespace AddisEatsNew.Api.Controllers;


[ApiController]
[Route("api/v1/[controller]")]

    public class MenuItemConrollers : ControllerBase
    {

    private readonly IMenuItemServices _menuItemService;
        public MenuItemConrollers(IMenuItemServices menuItemService)

    {
        _menuItemService = menuItemService;
    }

  [HttpGet()]
    public IActionResult GetAll([FromQuery] string? category)
    {
        var result = _menuItemService.GetAll(category);
        return Ok(result);

       
    
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {

        var result = _menuItemService.GetById(id);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);

    }


}



