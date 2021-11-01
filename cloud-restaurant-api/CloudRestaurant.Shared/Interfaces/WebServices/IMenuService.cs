using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudRestaurant.Shared.Interfaces.WebServices
{
    public interface IMenuService
    {
        IEnumerable<Menu> GetAll();

        Menu Create(Menu menu);

        Menu GetById(string id);

        bool Delete(string id);
    }
}
