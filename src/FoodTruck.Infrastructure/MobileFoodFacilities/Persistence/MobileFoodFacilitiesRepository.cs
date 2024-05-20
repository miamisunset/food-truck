using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Domain.MobileFoodFacilities;

namespace FoodTruck.Infrastructure.MobileFoodFacilities.Persistence;

internal class MobileFoodFacilitiesRepository : IMobileFoodFacilityRepository
{
    public Task<List<MobileFoodFacility>?> ListAsync()
    {
        throw new NotImplementedException();
    }
}
