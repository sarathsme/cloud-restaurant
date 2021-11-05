using CloudRestaurant.DAO.MongoDB.Interfaces;
using CloudRestaurant.DAO.MongoDB.Models;
using CloudRestaurant.DAO.MongoDB.Utils;
using CloudRestaurant.Shared.Interfaces.DataStore;
using CloudRestaurant.Shared.Models;
using EnsureThat;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace CloudRestaurant.DAO.MongoDB.Services
{
    public class DishDataStore : MenuDataStore, IDishDataStore
    {
        public DishDataStore(IDBConnection dbConnection) : base(dbConnection) { }

        public async Task<bool> Create(string menuId, Dish dish)
        {
            EnsureArg.IsNotNullOrWhiteSpace(menuId, nameof(menuId));
            EnsureArg.IsNotNull(dish, nameof(dish));

            ObjectId? objectId = menuId.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(menuId));

            DishDAO dishDAO = new DishDAO(dish);

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId);
            var pushCmd = Builders<MenuDAO>.Update.Push("Dishes", dishDAO);

            var result = await _MenuCollection.Value.UpdateOneAsync(filter, pushCmd);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Replace(string menuId, Guid dishId, Dish dish)
        {
            EnsureArg.IsNotNullOrWhiteSpace(menuId, nameof(menuId));
            EnsureArg.IsNot(dishId, Guid.Empty, nameof(dishId));
            EnsureArg.IsNotNull(dish, nameof(dish));

            ObjectId? objectId = menuId.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(menuId));

            DishDAO dishDAO = new DishDAO(dish);

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId) 
                            & Builders<MenuDAO>.Filter.Eq("Dishes.Id", dishId);

            var updateCmd = Builders<MenuDAO>.Update.Set("Dishes.$", dishDAO);

            var result = await _MenuCollection.Value.UpdateOneAsync(filter, updateCmd);

            // Can't use ModifiedCount as it can be 0, when the input document does not have any differences with matched the doc in the collection
            return result.MatchedCount == 1;
        }

        public async Task<bool> Delete(string menuId, Guid dishId)
        {
            EnsureArg.IsNotNullOrWhiteSpace(menuId, nameof(menuId));
            EnsureArg.IsNot(dishId, Guid.Empty, nameof(dishId));

            ObjectId? objectId = menuId.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(menuId));

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId);
            var updateCmd = Builders<MenuDAO>.Update.PullFilter("Dishes", Builders<DishDAO>.Filter.Where(dish => dish.Id == dishId));

            var result = await _MenuCollection.Value.UpdateOneAsync(filter, updateCmd);

            return result.ModifiedCount == 1;
        }
    }
}
