using System.Text.Json.Serialization;

namespace FoodTruck.Contracts.MobileFoodFacilities;

/// <summary>
/// Enumeration of facility types.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FacilityType
{
    Unknown,
    Truck,
    PushCart
}
