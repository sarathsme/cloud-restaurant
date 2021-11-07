using CloudRestaurant.Shared.Interfaces.WebServices;
using CloudRestaurant.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CloudRestaurant.API.Controllers.v1
{
    [Route("v1/Menu/{menuId}/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _DishService;

        public DishController(IDishService dishService)
        {
            _DishService = dishService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromRoute] string menuId, [FromBody] Dish dish)
        {
            if(await _DishService.Create(menuId, dish))
            {
                return NoContent();
            }
            else
            {
                return BadRequest($"The menu with ID: {menuId} was not found");
            }
        }

        [HttpPut("{dishId}")]
        public async Task<IActionResult> Update([FromRoute] string menuId, [FromRoute] Guid dishId, [FromBody] Dish dish)
        {
            if(await _DishService.Update(menuId, dishId, dish))
            {
                return NoContent();
            }
            else
            {
                return BadRequest($"Dish with ID: {dishId} and menu ID: {menuId} was not found");
            }
        }

        [HttpDelete("{dishId}")]
        public async Task<IActionResult> Delete([FromRoute] string menuId, [FromRoute] Guid dishId)
        {
            if (await _DishService.Delete(menuId, dishId))
            {
                return NoContent();
            }
            else
            {
                return BadRequest($"Dish with ID: {dishId} and menu ID: {menuId} was not found");
            }
        }
    }
}
