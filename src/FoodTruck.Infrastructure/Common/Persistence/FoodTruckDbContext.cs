using System.Reflection;
using FoodTruck.Domain.MobileFoodFacilities;
using Microsoft.EntityFrameworkCore;

namespace FoodTruck.Infrastructure.Common.Persistence;

/// <summary>
/// Represents the database context for the Food Truck application.
/// </summary>
public class FoodTruckDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<MobileFoodFacility> MobileFoodFacilities { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) => 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
