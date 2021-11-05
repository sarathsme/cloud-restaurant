using CloudRestaurant.Shared.Interfaces.DataStore;
using CloudRestaurant.Shared.Interfaces.WebServices;
using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudRestaurant.Services.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuDataStore _MenuDataStore;

        public MenuService(IMenuDataStore menuDataStore)
        {
            _MenuDataStore = menuDataStore;
        }

        public async Task<IEnumerable<Menu>> GetAll()
        {
            return await _MenuDataStore.GetAll();
        }

        public async Task<Menu> Create(Menu menu)
        {
            return await _MenuDataStore.Create(menu);
        }

        public async Task<Menu> GetById(string id)
        {
            return await _MenuDataStore.GetById(id);
        }

        public async Task<bool> Delete(string id)
        {
            return await _MenuDataStore.Delete(id);
        }

        public async Task<bool> Update(string id, Menu menu)
        {
            return await _MenuDataStore.Replace(id, menu);
        }
    }
}
