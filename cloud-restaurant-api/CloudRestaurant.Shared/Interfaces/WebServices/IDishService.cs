﻿using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudRestaurant.Shared.Interfaces.WebServices
{
    public interface IDishService
    {
        bool Create(string menuId, Dish dish);

        bool Update(string menuId, Guid dishId, Dish dish);

        bool Delete(string menuId, Guid dishId);
    }
}
