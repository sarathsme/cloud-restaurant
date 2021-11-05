using CloudRestaurant.DAO.MongoDB.Interfaces;
using CloudRestaurant.DAO.MongoDB.Models;
using CloudRestaurant.DAO.MongoDB.Utils;
using CloudRestaurant.Shared.Interfaces.DataStore;
using CloudRestaurant.Shared.Models;
using EnsureThat;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudRestaurant.DAO.MongoDB.Services
{
    public class MenuDataStore : IMenuDataStore
    {
        protected const string MENU_COLLECTION_NAME = "Menu";
        protected readonly IMongoDatabase _RestaurantDb;
        protected readonly Lazy<IMongoCollection<MenuDAO>> _MenuCollection;

        public MenuDataStore(IDBConnection dbConnection)
        {
            _RestaurantDb = dbConnection.GetRestaurantDB();
            _MenuCollection = new Lazy<IMongoCollection<MenuDAO>>(GetMenuCollection);
        }

        private IMongoCollection<MenuDAO> GetMenuCollection() => _RestaurantDb.GetCollection<MenuDAO>(MENU_COLLECTION_NAME);

        public async Task<IEnumerable<Menu>> GetAll()
        {
            var filter = Builders<MenuDAO>.Filter.Empty;
            var result = await _MenuCollection.Value.FindAsync(filter);

            return result.ToEnumerable()
                    .Select(menu => menu.ToAPIServiceModel());
        }

        public async Task<Menu> Create(Menu menu)
        {
            EnsureArg.IsNotNull(menu, nameof(menu));

            MenuDAO menuDAO = new MenuDAO(menu);
            await _MenuCollection.Value.InsertOneAsync(menuDAO);

            return menuDAO.ToAPIServiceModel();
        }

        public async Task<Menu> GetById(string id)
        {
            EnsureArg.IsNotNullOrWhiteSpace(id, nameof(id));

            ObjectId? objectId = id.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(id));

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId);
            var result = await _MenuCollection.Value.FindAsync(filter);
                
            return result.FirstOrDefault()?.ToAPIServiceModel();
        }

        public async Task<bool> Delete(string id)
        {
            EnsureArg.IsNotNullOrWhiteSpace(id, nameof(id));

            ObjectId? objectId = id.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(id));

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId);
            var result = await _MenuCollection.Value.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }

        public async Task<bool> Replace(string id, Menu menu)
        {
            EnsureArg.IsNotNullOrWhiteSpace(id, nameof(id));
            EnsureArg.IsNotNull(menu, nameof(menu));

            ObjectId? objectId = id.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(id));

            MenuDAO menuDAO = new MenuDAO(menu);

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId);
            var result = await _MenuCollection.Value.ReplaceOneAsync(filter, menuDAO);

            // Can't use ModifiedCount as it can be 0, when the input document does not have any differences with matched the doc in the collection
            return result.MatchedCount == 1;
        }
    }
}
