using MongoDB.Bson;

namespace CloudRestaurant.DAO.MongoDB.Utils
{
    public static class MongoUtils
    {
        public static ObjectId? ToObjectId(this string objectIdString)
        {
            if (ObjectId.TryParse(objectIdString, out ObjectId objectId))
            {
                return objectId;
            }

            return null;
        }
    }
}
