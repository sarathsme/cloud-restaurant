using CloudRestaurant.Shared.Models;
using CloudRestaurant.Shared.Interfaces.WebServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudRestaurant.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _MenuService;

        public MenuController(IMenuService menuService)
        {
            _MenuService = menuService;
        }

        // TODO: Filtering, pagination, sorting
        [HttpGet]
        public async Task<IEnumerable<Menu>> GetAll()
        {
            return await _MenuService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Menu menu)
        {
            var createdMenu = await _MenuService.Create(menu);
            return CreatedAtAction(nameof(GetById), new { id = createdMenu.Id }, createdMenu);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var menu = await _MenuService.GetById(id);
            if (menu == null)
                return NotFound();

            return Ok(menu);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (await _MenuService.Delete(id))
            {
                return NoContent();
            }
            else
            {
                return BadRequest($" Menu with id: {id} was not found");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Menu menu)
        {
            if(await _MenuService.Update(id, menu))
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
