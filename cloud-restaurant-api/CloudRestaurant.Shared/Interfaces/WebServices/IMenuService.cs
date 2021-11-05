using CloudRestaurant.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudRestaurant.Shared.Interfaces.WebServices
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetAll();

        Task<Menu> Create(Menu menu);

        Task<Menu> GetById(string id);

        Task<bool> Delete(string id);

        Task<bool> Update(string id, Menu menu);
    }
}
