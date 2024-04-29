using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateBackend.Application.Contracts.Persistence;
using RealEstateBackend.Persistence.DatabaseContext;
using RealEstateBackend.Persistence.Repositories;

namespace RealEstateBackend.Persistence
{
    public static class PersistenceServiceConfiguration
    {
        public static IServiceCollection PersistenceConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(z => z.UseSqlServer(configuration.GetConnectionString("DefaultConnetion")));
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            return services;
        }
    }
}
