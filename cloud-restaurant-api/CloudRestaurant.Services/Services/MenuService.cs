using CloudRestaurant.Shared.Interfaces.DataStore;
using CloudRestaurant.Shared.Interfaces.WebServices;
using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudRestaurant.Services.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuDataStore _MenuDataStore;

        public MenuService(IMenuDataStore menuDataStore)
        {
            _MenuDataStore = menuDataStore;
        }

        public IEnumerable<Menu> GetAll()
        {
            return _MenuDataStore.GetAll();
        }

        public Menu Create(Menu menu)
        {
            return _MenuDataStore.Create(menu);
        }

        public Menu GetById(string id)
        {
            return _MenuDataStore.GetById(id);
        }

        public bool Delete(string id)
        {
            return _MenuDataStore.Delete(id);
        }
    }
}
