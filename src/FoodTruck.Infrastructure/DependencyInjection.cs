using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Infrastructure.Common.Persistence;
using FoodTruck.Infrastructure.MobileFoodFacilities.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FoodTruck.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) => 
        services.AddPersistence();

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<FoodTruckDbContext>(options =>
            options.UseSqlite("Data Source = Truck.db"));

        services.AddScoped<IMobileFoodFacilityRepository, MobileFoodFacilitiesRepository>();
        return services;
    }
}
