using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudRestaurant.Shared.Interfaces.DataStore
{
    public interface IMenuDataStore
    {
        IEnumerable<Menu> GetAll();

        Menu Create(Menu menu);
    }
}
