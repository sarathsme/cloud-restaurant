using CloudRestaurant.Shared.Interfaces.WebServices;
using CloudRestaurant.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CloudRestaurant.API.Controllers.v1
{
    [Route("api/v1/Menu/{menuId}/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _DishService;

        public DishController(IDishService dishService)
        {
            _DishService = dishService;
        }

        [HttpPut("{dishId}")]
        public IActionResult Update([FromRoute] string menuId, [FromRoute] Guid? dishId, [FromBody] Dish dish)
        {
            if(_DishService.Update(menuId, dishId, dish))
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
