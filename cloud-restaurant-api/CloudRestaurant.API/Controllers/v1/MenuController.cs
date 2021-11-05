using CloudRestaurant.Shared.Models;
using CloudRestaurant.Shared.Interfaces.WebServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudRestaurant.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _MenuService;

        public MenuController(IMenuService menuService)
        {
            _MenuService = menuService;
        }

        // TODO: Filtering, pagination, sorting
        [HttpGet]
        public IEnumerable<Menu> GetAll()
        {
            return _MenuService.GetAll();
        }

        [HttpPost]
        public IActionResult Create(Menu menu)
        {
            var createdMenu = _MenuService.Create(menu);
            return CreatedAtAction(nameof(GetById), new { id = createdMenu.Id }, createdMenu);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            var menu = _MenuService.GetById(id);
            if (menu == null)
                return NotFound();

            return Ok(menu);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            if (_MenuService.Delete(id))
            {
                return NoContent();
            }
            else
            {
                return BadRequest($" Menu with id: {id} was not found");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] string id, [FromBody] Menu menu)
        {
            if(_MenuService.Update(id, menu))
            {
                return NoContent();
            }
            else
            {
                return BadRequest($"The Menu with id: {id} was not found");
            }
        }
    }
}
