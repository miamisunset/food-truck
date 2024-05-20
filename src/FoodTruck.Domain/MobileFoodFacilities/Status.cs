using Ardalis.SmartEnum;

namespace FoodTruck.Domain.MobileFoodFacilities;

public class Status(
    string name, 
    int value) 
    : SmartEnum<Status>(name, value)
{
    public static readonly Status Requested = new(nameof(Requested).ToUpper(), 0);
    public static readonly Status Approved = new(nameof(Approved).ToUpper(), 1);
    public static readonly Status Expired = new(nameof(Expired).ToUpper(), 2);
}
