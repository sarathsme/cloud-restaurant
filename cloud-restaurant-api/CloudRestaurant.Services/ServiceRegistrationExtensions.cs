using CloudRestaurant.Services.Services;
using CloudRestaurant.Shared.Interfaces.WebServices;
using Microsoft.Extensions.DependencyInjection;
using CloudRestaurant.DAO.MongoDB;

namespace CloudRestaurant.Services
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddAPIServices(this IServiceCollection services)
        {
            services.AddSingleton<IMenuService, MenuService>();
            services.AddMongoDb();
        }
    }
}
