using CloudRestaurant.Shared.Models;
using CloudRestaurant.Shared.Interfaces.WebServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudRestaurant.Shared.Models;

namespace CloudRestaurant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _MenuService;

        public MenuController(IMenuService menuService)
        {
            _MenuService = menuService;
        }

        [HttpGet]
        public IEnumerable<Menu> Get()
        {
            return _MenuService.GetAll();
        }

        [HttpPost]
        public IActionResult Create(Menu menu)
        {
            var createdMenu = _MenuService.Create(menu);
            return Created($"{Request.Path}/{createdMenu.Id}", createdMenu);
            //TODO
            //return CreatedAtAction(nameof(Get), new { id =  })
        }
    }
}
