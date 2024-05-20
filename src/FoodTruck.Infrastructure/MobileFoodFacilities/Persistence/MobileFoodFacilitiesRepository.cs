using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Domain.MobileFoodFacilities;
using FoodTruck.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FoodTruck.Infrastructure.MobileFoodFacilities.Persistence;

internal class MobileFoodFacilitiesRepository(FoodTruckDbContext dbContext) : IMobileFoodFacilityRepository
{
    public async Task<List<MobileFoodFacility>?> ListAsync() => 
        await dbContext.MobileFoodFacilities.ToListAsync();

    public async Task<MobileFoodFacility?> GetByLocationId(int locationId) =>
        await dbContext.MobileFoodFacilities
            .Where(mff => mff.LocationId == locationId)
            .FirstOrDefaultAsync();
}
