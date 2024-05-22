using FoodTruck.Domain.MobileFoodFacilities;

namespace FoodTruck.Application.Common.Interfaces;

/// <summary>
/// Provides an interface for accessing mobile food facility data.
/// </summary>
public interface IMobileFoodFacilityRepository
{
    Task<List<MobileFoodFacility>?> ListAsync(int page, int size);
    Task<MobileFoodFacility?> GetByLocationId(int locationId);
    Task<List<MobileFoodFacility>?> GetByApplicant(string applicant);
}
