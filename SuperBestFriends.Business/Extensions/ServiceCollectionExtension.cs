using Microsoft.Extensions.DependencyInjection;
using SuperBestFriends.Business.Abstractions;
using SuperBestFriends.Business.Services;

namespace SuperBestFriends.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAdminService, AdminService>();
            return services;
        }
    }
}
