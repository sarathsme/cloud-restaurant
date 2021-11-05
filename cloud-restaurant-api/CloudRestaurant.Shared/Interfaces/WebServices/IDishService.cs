using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudRestaurant.Shared.Interfaces.WebServices
{
    public interface IDishService
    {
        Task<bool> Create(string menuId, Dish dish);

        Task<bool> Update(string menuId, Guid dishId, Dish dish);

        Task<bool> Delete(string menuId, Guid dishId);
    }
}
