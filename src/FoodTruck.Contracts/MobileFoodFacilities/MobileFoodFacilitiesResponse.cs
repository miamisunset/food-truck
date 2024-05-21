namespace FoodTruck.Contracts.MobileFoodFacilities;

public record MobileFoodFacilitiesResponse(
    int LocationId,
    string Name,
    FacilityType? FacilityType,
    int Cnn,
    string? LocationDescription,
    string Address,
    string? BlockLot,
    string? FoodItems,
    float Longitude,
    float Latitude);
