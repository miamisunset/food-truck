using System.Text.Json.Serialization;

namespace FoodTruck.Contracts.MobileFoodFacilities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FacilityType
{
    Unknown,
    Truck,
    PushCart
}
