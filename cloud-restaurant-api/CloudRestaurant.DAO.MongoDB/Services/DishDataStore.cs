using CloudRestaurant.DAO.MongoDB.Interfaces;
using CloudRestaurant.DAO.MongoDB.Models;
using CloudRestaurant.DAO.MongoDB.Utils;
using CloudRestaurant.Shared.Interfaces.DataStore;
using CloudRestaurant.Shared.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudRestaurant.DAO.MongoDB.Services
{
    public class DishDataStore : MenuDataStore, IDishDataStore
    {
        public DishDataStore(IDBConnection dbConnection) : base(dbConnection) { }

        public bool Replace(string menuId, Guid dishId, Dish dish)
        {
            throw new NotImplementedException();
        }
    }
}
