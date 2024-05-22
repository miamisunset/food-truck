namespace FoodTruck.Contracts.MobileFoodFacilities;

/// <summary>
/// Represents the response object for mobile food facilities.
/// </summary>
public record MobileFoodFacilitiesResponse(
    int LocationId,
    string Name,
    FacilityType? FacilityType,
    int Cnn,
    string? LocationDescription,
    string Address,
    string? BlockLot,
    string? FoodItems,
    Geolocation Geolocation);
