using ErrorOr;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

/// <summary>
/// Represents a query to fetch a mobile food facility by location ID.
/// </summary>
/// <remarks>
/// This query is used to retrieve a mobile food facility based on its location ID.
/// It is typically used in the context of the "GetMobileFoodFacilityByLocationId" API endpoint.
/// </remarks>
public record GetByLocationIdQuery(int LocationId) : IRequest<ErrorOr<MobileFoodFacility>>;
