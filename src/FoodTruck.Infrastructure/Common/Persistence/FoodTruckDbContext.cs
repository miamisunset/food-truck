using System.Reflection;
using FoodTruck.Domain.MobileFoodFacilities;
using Microsoft.EntityFrameworkCore;

namespace FoodTruck.Infrastructure.Common.Persistence;

internal class FoodTruckDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<MobileFoodFacility> MobileFoodFacilities { get; set; } = null!;

    public async Task CommitChangesAsync() => await SaveChangesAsync();

    protected override void OnModelCreating(ModelBuilder modelBuilder) => 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
