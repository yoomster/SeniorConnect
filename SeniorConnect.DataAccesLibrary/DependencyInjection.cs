using Microsoft.Extensions.DependencyInjection;
using SeniorConnect.Application.Interfaces;
using SeniorConnect.Application.Services;
using SeniorConnect.DataAccesLibrary;

namespace SeniorConnect.DataAccessLibrary
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<DataAccess>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();


            return services;
        }
    }
}
