using CloudRestaurant.Services.Services;
using CloudRestaurant.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CloudRestaurant.Services
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddAPIServices(this IServiceCollection services)
        {
            services.AddSingleton<IMenuService, MenuService>();
        }
    }
}
