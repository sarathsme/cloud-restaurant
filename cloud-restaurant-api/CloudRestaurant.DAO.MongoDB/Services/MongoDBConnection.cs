using CloudRestaurant.DAO.MongoDB.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CloudRestaurant.DAO.MongoDB.Services
{
    public class MongoDBConnection : IDBConnection
    {
        private const string RESTUARANT_DB_NAME = "cloud-restaurant";

        private readonly MongoClient _MongoClient;
        private readonly IMongoDatabase _RestaurantDB;

        public IMongoDatabase GetRestaurantDB() => _RestaurantDB;

        public MongoDBConnection(IConfiguration config)
        {
            _MongoClient = new MongoClient(config.GetConnectionString("MongoDB"));
            _RestaurantDB = _MongoClient.GetDatabase(RESTUARANT_DB_NAME);
        }
    }
}
