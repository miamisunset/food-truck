namespace FoodTruck.Domain.MobileFoodFacilities;

public class MobileFoodFacility
{
    public int LocationId { get; init; }
    public string Applicant { get; init; } = string.Empty;
    public FacilityType FacilityType { get; init; } = FacilityType.Unknown;
    public int Cnn { get; init; }
    public string? LocationDescription { get; init; }
    public string Address { get; init; } = string.Empty;
    public int BlockLot { get; init; }
    public int Block { get; init; }
    public int Lot { get; init; }
    public Status Status { get; init; } = Status.Expired;
    public string FoodItems { get; init; } = string.Empty;
    public int X { get; init; }
    public int Y { get; init; }
    public int Latitude { get; init; }
    public int Longitude { get; init; }
    public string Schedule { get; init; } = string.Empty;
    public string? DaysHours { get; init; }
    public DateTime Approved { get; init; }
    public int Received { get; init; }
    public bool PriorPermit { get; init; }
    public DateTime ExpirationDate { get; init; }
    public int FirePreventionDistricts { get; init; }
    public int PoliceDistricts { get; init; }
    public int SupervisorDistricts { get; init; }
    public int ZipCodes { get; init; }
    public int Neighborhoods { get; init; }
}
