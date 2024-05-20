namespace FoodTruck.Domain.MobileFoodFacilities;

public class MobileFoodFacility
{
    public int LocationId { get; set; }
    public string Applicant { get; set; } = string.Empty;
    public FacilityType? FacilityType { get; set; }
    public int Cnn { get; set; }
    public string? LocationDescription { get; set; }
    public string Address { get; set; } = string.Empty;
    public string? BlockLot { get; set; }
    public string? Block { get; set; }
    public string? Lot { get; set; }
    public string Permit { get; set; } = string.Empty;
    public Status Status { get; set; } = Status.Approved;
    public string? FoodItems { get; set; }
    public int? X { get; set; }
    public int? Y { get; set; }
    public int Latitude { get; set; }
    public int Longitude { get; set; }
    public string Schedule { get; set; } = string.Empty;
    public string? DaysHours { get; set; }
    public DateTime? Approved { get; set; }
    public int Received { get; set; }
    public bool PriorPermit { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public int? FirePreventionDistricts { get; set; }
    public int? PoliceDistricts { get; set; }
    public int? SupervisorDistricts { get; set; }
    public int? ZipCodes { get; set; }
    public int? Neighborhoods { get; set; }
}
