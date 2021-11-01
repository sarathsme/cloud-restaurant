using CloudRestaurant.DAO.MongoDB.Interfaces;
using CloudRestaurant.Shared.Configs;
using MongoDB.Driver;

namespace CloudRestaurant.DAO.MongoDB.Services
{
    public class MongoDBConnection : IDBConnection
    {
        private const string RESTUARANT_DB_NAME = "cloud-restaurant";

        private readonly MongoClient _MongoClient;
        private readonly IMongoDatabase _RestaurantDB;

        public IMongoDatabase GetRestaurantDB() => _RestaurantDB;

        public MongoDBConnection()
        {
            _MongoClient = new MongoClient(AppSettings.MongoConnectionString);
            _RestaurantDB = _MongoClient.GetDatabase(RESTUARANT_DB_NAME);
        }
    }
}
