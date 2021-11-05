using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudRestaurant.Shared.Interfaces.DataStore
{
    public interface IMenuDataStore
    {
        Task<IEnumerable<Menu>> GetAll();

        Task<Menu> Create(Menu menu);

        Task<Menu> GetById(string id);

        Task<bool> Delete(string id);

        Task<bool> Replace(string id, Menu menu);
    }
}
