using FoodTruck.Domain.MobileFoodFacilities;

namespace FoodTruck.Application.Common.Interfaces;

public interface IMobileFoodFacilityRepository
{
    Task<List<MobileFoodFacility>?> ListAsync();
    Task<MobileFoodFacility?> GetByLocationId(int locationId);
}
