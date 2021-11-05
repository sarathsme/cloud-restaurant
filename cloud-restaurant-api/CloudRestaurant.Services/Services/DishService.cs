using CloudRestaurant.Shared.Interfaces.DataStore;
using CloudRestaurant.Shared.Interfaces.WebServices;
using CloudRestaurant.Shared.Models;
using System;
using System.Threading.Tasks;

namespace CloudRestaurant.Services.Services
{
    public class DishService : IDishService
    {
        private readonly IDishDataStore _DishDataStore;

        public DishService(IDishDataStore dishDataStore)
        {
            _DishDataStore = dishDataStore;
        }

        public async Task<bool> Create(string menuId, Dish dish)
        {
            return await _DishDataStore.Create(menuId, dish);
        }

        public async Task<bool> Update(string menuId, Guid dishId, Dish dish)
        {
            return await _DishDataStore.Replace(menuId, dishId, dish);
        }

        public async Task<bool> Delete(string menuId, Guid dishId)
        {
            return await _DishDataStore.Delete(menuId, dishId);
        }
    }
}