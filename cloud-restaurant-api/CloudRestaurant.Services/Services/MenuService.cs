using CloudRestaurant.Shared.Interfaces;
using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudRestaurant.Services.Services
{
    public class MenuService : IMenuService
    {
        public MenuService()
        {

        }

        public List<Menu> GetAllMenus()
        {
            return new List<Menu>();
        }
    }
}
