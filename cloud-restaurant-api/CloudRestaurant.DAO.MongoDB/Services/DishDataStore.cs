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

        public bool Create(string menuId, Dish dish)
        {
            ObjectId? objectId = menuId.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(menuId));

            DishDAO dishDAO = new DishDAO(dish);

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId);
            var pushCmd = Builders<MenuDAO>.Update.Push("Dishes", dishDAO);

            var result = _MenuCollection.Value.UpdateOne(filter, pushCmd);

            return result.ModifiedCount == 1;
        }

        public bool Replace(string menuId, Guid dishId, Dish dish)
        {
            //TODO: Add custom exceptions, null checks
            ObjectId? objectId = menuId.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(menuId));

            DishDAO dishDAO = new DishDAO(dish);

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId) 
                            & Builders<MenuDAO>.Filter.Eq("Dishes.Id", dishId);

            var updateCmd = Builders<MenuDAO>.Update.Set("Dishes.$", dishDAO);

            var result = _MenuCollection.Value.UpdateOne(filter, updateCmd);

            // Can't use ModifiedCount as it can be 0, when the input document does not have any differences with matched the doc in the collection
            return result.MatchedCount == 1;
        }

        public bool Delete(string menuId, Guid dishId)
        {
            ObjectId? objectId = menuId.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(menuId));

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId);
            var updateCmd = Builders<MenuDAO>.Update.PullFilter("Dishes", Builders<DishDAO>.Filter.Where(dish => dish.Id == dishId));

            var result = _MenuCollection.Value.UpdateOne(filter, updateCmd);

            return result.ModifiedCount == 1;
        }
    }
}
