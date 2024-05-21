using ErrorOr;
using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

/// <summary>
/// Represents a query handler for fetching a mobile food facility by location ID.
/// </summary>
public class GetByLocationIdQueryHandler(
    IMobileFoodFacilityRepository repository)
    : IRequestHandler<GetByLocationIdQuery, ErrorOr<MobileFoodFacility>>
{
    /// <summary>
    /// Handles the GetByLocationIdQuery to fetch a mobile food facility by location ID.
    /// </summary>
    /// <param name="query">The GetByLocationIdQuery containing the location ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>An ErrorOr object with the result of the query.</returns>
    public async Task<ErrorOr<MobileFoodFacility>> Handle(
        GetByLocationIdQuery query, 
        CancellationToken cancellationToken)
    {
        var foodFacility = await repository.GetByLocationId(query.LocationId);

        return foodFacility is null
            ? Error.NotFound($"{query.LocationId} mobile food facility not found")
            : foodFacility;
    }
}
