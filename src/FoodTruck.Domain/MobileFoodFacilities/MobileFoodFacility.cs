namespace FoodTruck.Domain.MobileFoodFacilities;

public class MobileFoodFacility
{
    public int LocationId { get; init; }
    public string Applicant { get; init; } = string.Empty;
    public FacilityType? FacilityType { get; init; }
    public int Cnn { get; init; }
    public string? LocationDescription { get; init; }
    public string Address { get; init; } = string.Empty;
    public string? BlockLot { get; init; }
    public string? Block { get; init; }
    public string? Lot { get; init; }
    public string Permit { get; init; } = string.Empty;
    public Status Status { get; init; } = Status.Approved;
    public string? FoodItems { get; init; }
    public int? X { get; init; }
    public int? Y { get; init; }
    public int Latitude { get; init; }
    public int Longitude { get; init; }
    public string Schedule { get; init; } = string.Empty;
    public string? DaysHours { get; init; }
    public DateTime? Approved { get; init; }
    public int Received { get; init; }
    public bool PriorPermit { get; init; }
    public DateTime? ExpirationDate { get; init; }
    public int? FirePreventionDistricts { get; init; }
    public int? PoliceDistricts { get; init; }
    public int? SupervisorDistricts { get; init; }
    public int? ZipCodes { get; init; }
    public int? Neighborhoods { get; init; }
}
