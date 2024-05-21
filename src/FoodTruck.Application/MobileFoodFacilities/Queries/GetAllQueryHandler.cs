using ErrorOr;
using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

/// <summary>
/// The GetAllQueryHandler class is responsible for handling the GetAllQuery to retrieve all mobile food facilities.
/// </summary>
public class GetAllQueryHandler(
    IMobileFoodFacilityRepository repository) 
    : IRequestHandler<GetAllQuery, ErrorOr<List<MobileFoodFacility>>>
{
    /// <summary>
    /// Handles the GetAllQuery to retrieve all mobile food facilities.
    /// </summary>
    /// <param name="query">The GetAllQuery object.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>An ErrorOr object containing the list of MobileFoodFacility objects on success, or an error message on failure.</returns>
    public async Task<ErrorOr<List<MobileFoodFacility>>> Handle(
        GetAllQuery query, 
        CancellationToken cancellationToken)
    {
        var foodFacilities = await repository.ListAsync();

        return foodFacilities is null || foodFacilities.Count is 0
            ? Error.NotFound(description: "No food trucks or carts found")
            : foodFacilities;
    }
}
