using CloudRestaurant.DAO.MongoDB.Interfaces;
using CloudRestaurant.DAO.MongoDB.Services;
using CloudRestaurant.Shared.Interfaces.DataStore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudRestaurant.DAO.MongoDB
{
    public static class MongoRegistrationExtensions
    {
        public static void AddMongoDb(this IServiceCollection serviceCollection)
        {
            // Mongo connection service.
            serviceCollection.AddSingleton<IDBConnection, MongoDBConnection>();

            // Add all database's data stores here:
            serviceCollection.AddSingleton<IMenuDataStore, MenuDataStore>();
            serviceCollection.AddSingleton<IDishDataStore, DishDataStore>();
        }
    }
}
