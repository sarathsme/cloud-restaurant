using CloudRestaurant.DAO.MongoDB.Interfaces;
using CloudRestaurant.DAO.MongoDB.Models;
using CloudRestaurant.DAO.MongoDB.Utils;
using CloudRestaurant.Shared.Interfaces.DataStore;
using CloudRestaurant.Shared.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudRestaurant.DAO.MongoDB.Services
{
    public class MenuDataStore : IMenuDataStore
    {
        private const string MENU_COLLECTION_NAME = "Menu";
        private readonly IMongoDatabase _RestaurantDb;
        private readonly Lazy<IMongoCollection<MenuDAO>> _MenuCollection;

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

            return menuDAOs.Select(menu => menu.ToAPIModel());
        }

        public Menu Create(Menu menu)
        {
            //TODO: Add exceptions, null checks
            MenuDAO menuDAO = new MenuDAO(menu);
            _MenuCollection.Value.InsertOne(menuDAO);

            // TODO: Check inserted counted????
            return menuDAO.ToAPIModel();
        }

        public Menu GetById(string id)
        {
            //TODO: Add custom exceptions, null checks
            ObjectId? objectId = id.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(id));

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId);
            return _MenuCollection.Value.Find(filter).FirstOrDefault()?.ToAPIModel();
        }

        public bool Delete(string id)
        {
            //TODO: Add custom exceptions, null checks, refactor??
            ObjectId? objectId = id.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(id));

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId);
            var result = _MenuCollection.Value.DeleteOne(filter);

            return result.DeletedCount == 1;
        }

        public bool Replace(string id, Menu menu)
        {
            //TODO: Add custom exceptions, null checks
            ObjectId? objectId = id.ToObjectId();
            if (objectId == null) throw new ArgumentException(nameof(id));

            MenuDAO menuDAO = new MenuDAO(menu);

            var filter = Builders<MenuDAO>.Filter.Eq("Id", objectId);
            var result = _MenuCollection.Value.ReplaceOne(filter, menuDAO);

            return result.ModifiedCount == 1;
        }
    }
}
