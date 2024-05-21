using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Infrastructure.Common.Persistence;
using FoodTruck.Infrastructure.MobileFoodFacilities.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodTruck.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) => 
        services.AddPersistence(configuration);

    private static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<FoodTruckDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IMobileFoodFacilityRepository, MobileFoodFacilitiesRepository>();
        return services;
    }
}
