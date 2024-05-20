namespace FoodTruck.Contracts.MobileFoodFacilities;

public record MobileFoodFacilitiesResponse(
    int LocationId,
    string Applicant,
    FacilityType FacilityType,
    int Cnn,
    string? LocationDescription,
    string Address,
    int BlockLot,
    string FoodItems,
    int Longitude,
    int Latitude);
