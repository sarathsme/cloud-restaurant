using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudRestaurant.Shared.Interfaces
{
    public interface IMenuService
    {
        List<Menu> GetAllMenus();
    }
}
