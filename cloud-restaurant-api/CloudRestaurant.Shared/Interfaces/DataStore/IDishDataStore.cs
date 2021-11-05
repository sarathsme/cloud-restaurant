using CloudRestaurant.Shared.Models;
using System;
using System.Threading.Tasks;

namespace CloudRestaurant.Shared.Interfaces.DataStore
{
    public interface IDishDataStore
    {
        Task<bool> Create(string menuId, Dish dish);

        Task<bool> Replace(string menuId, Guid dishId, Dish dish);

        Task<bool> Delete(string menuId, Guid dishId);
    }
}
