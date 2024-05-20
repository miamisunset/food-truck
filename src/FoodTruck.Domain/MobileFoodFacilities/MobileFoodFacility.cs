namespace FoodTruck.Domain.MobileFoodFacilities;

public class MobileFoodFacility
{
    public int LocationId { get; set; }
    public string Applicant { get; set; } = string.Empty;
    public FacilityType FacilityType { get; set; } = FacilityType.Unknown;
    public int Cnn { get; set; }
    public string? LocationDescription { get; set; }
    public string Address { get; set; } = string.Empty;
    public int BlockLot { get; set; }
    public int Block { get; set; }
    public int Lot { get; set; }
    public Status Status { get; set; } = Status.Expired;
    public string FoodItems { get; set; } = string.Empty;
    public int X { get; set; }
    public int Y { get; set; }
    public int Latitude { get; set; }
    public int Longitude { get; set; }
    public string Schedule { get; set; } = string.Empty;
    public string? DaysHours { get; set; }
    public DateTime Approved { get; set; }
    public int Received { get; set; }
    public bool PriorPermit { get; set; }
    public DateTime ExpirationDate { get; set; }
}
