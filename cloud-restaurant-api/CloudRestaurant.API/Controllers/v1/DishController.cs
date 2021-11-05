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
        public bool Update([FromRoute] string menuId, [FromRoute] Guid? dishId, [FromBody] Dish dish)
        {
            return _DishService.Update(menuId, dishId, dish);
        }
    }
}
