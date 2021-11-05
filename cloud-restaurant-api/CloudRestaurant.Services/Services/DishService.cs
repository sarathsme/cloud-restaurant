using CloudRestaurant.Shared.Interfaces.DataStore;
using CloudRestaurant.Shared.Interfaces.WebServices;
using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudRestaurant.Services.Services
{
    public class DishService : IDishService
    {
        private readonly IDishDataStore _DishDataStore;

        public DishService(IDishDataStore dishDataStore)
        {
            _DishDataStore = dishDataStore;
        }

        public bool Create(string menuId, Dish dish)
        {
            return _DishDataStore.Create(menuId, dish);
        }

        public bool Update(string menuId, Guid? dishId, Dish dish)
        {
            return _DishDataStore.Replace(menuId, dishId.Value, dish);
        }
    }
}