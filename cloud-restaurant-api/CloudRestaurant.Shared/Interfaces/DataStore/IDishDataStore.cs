using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudRestaurant.Shared.Interfaces.DataStore
{
    public interface IDishDataStore
    {
        bool Replace(string menuId, Guid dishId, Dish dish);
    }
}
