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

        public IEnumerable<Menu> GetAll()
        {
            var filter = Builders<MenuDAO>.Filter.Empty;
            var menuDAOs = _MenuCollection.Value.Find(filter).ToEnumerable();

            return menuDAOs.Select(menu => menu.ToAPIServiceModel());
        }

        public Menu Create(Menu menu)
        {
            EnsureArg.IsNotNull(menu, nameof(menu));

            MenuDAO menuDAO = new MenuDAO(menu);
            _MenuCollection.Value.InsertOne(menuDAO);

            return menuDAO.ToAPIServiceModel();
        }

        public Menu GetById(string id)
        {
            EnsureArg.IsNotNullOrWhiteSpace(id, nameof(id));

            ObjectId? objectId = id.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(id));

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId);

            return _MenuCollection.Value.Find(filter).FirstOrDefault()?.ToAPIServiceModel();
        }

        public bool Delete(string id)
        {
            EnsureArg.IsNotNullOrWhiteSpace(id, nameof(id));

            ObjectId? objectId = id.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(id));

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId);
            var result = _MenuCollection.Value.DeleteOne(filter);

            return result.DeletedCount == 1;
        }

        public bool Replace(string id, Menu menu)
        {
            EnsureArg.IsNotNullOrWhiteSpace(id, nameof(id));
            EnsureArg.IsNotNull(menu, nameof(menu));

            ObjectId? objectId = id.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(id));

            MenuDAO menuDAO = new MenuDAO(menu);

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId);
            var result = _MenuCollection.Value.ReplaceOne(filter, menuDAO);

            // Can't use ModifiedCount as it can be 0, when the input document does not have any differences with matched the doc in the collection
            return result.MatchedCount == 1;
        }
    }
}
