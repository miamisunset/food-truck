using Ardalis.SmartEnum;

namespace FoodTruck.Domain.MobileFoodFacilities;

public class FacilityType(
    string name, 
    int value) 
    : SmartEnum<FacilityType>(name, value)
{
    public static readonly FacilityType Unknown = new(nameof(Unknown), 0);
    public static readonly FacilityType FoodTruck = new("Food Truck", 1);
    public static readonly FacilityType PushCart = new("Push Cart", 2);
}
