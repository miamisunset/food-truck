using Ardalis.SmartEnum;

namespace FoodTruck.Domain.MobileFoodFacilities;

public class FacilityType(
    string name, 
    int value) 
    : SmartEnum<FacilityType>(name, value)
{
    public static readonly FacilityType Truck = new("Truck", 1);
    public static readonly FacilityType PushCart = new("Push Cart", 2);
}
