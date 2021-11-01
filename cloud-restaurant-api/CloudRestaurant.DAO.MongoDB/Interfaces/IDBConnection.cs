using MongoDB.Driver;

namespace CloudRestaurant.DAO.MongoDB.Interfaces
{
    public interface IDBConnection
    {
        IMongoDatabase GetRestaurantDB();
    }
}
