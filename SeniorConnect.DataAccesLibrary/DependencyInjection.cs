using Microsoft.Extensions.DependencyInjection;
using SeniorConnect.Application.Interfaces;
using SeniorConnect.DataAccesLibrary;

namespace SeniorConnect.DataAccessLibrary
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
