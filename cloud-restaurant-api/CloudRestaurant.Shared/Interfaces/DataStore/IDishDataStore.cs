using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudRestaurant.Shared.Interfaces.DataStore
{
    public interface IDishDataStore
    {
        bool Create(string menuId, Dish dish);

        bool Replace(string menuId, Guid dishId, Dish dish);

        bool Delete(string menuId, Guid dishId);
    }
}
