using ErrorOr;
using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

/// <summary>
/// Handles the GetByNameQuery to retrieve a list of mobile food facilities by applicant name.
/// </summary>
public class GetByNameQueryHandler(
    IMobileFoodFacilityRepository repository) 
    : IRequestHandler<GetByNameQuery, ErrorOr<List<MobileFoodFacility>>>
{
    /// <summary>
    /// Handles the GetByNameQuery to retrieve a list of mobile food facilities by applicant name.
    /// </summary>
    /// <param name="query">The GetByNameQuery object.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of mobile food facilities matching the applicant name.</returns>
    public async Task<ErrorOr<List<MobileFoodFacility>>> Handle(
        GetByNameQuery query, 
        CancellationToken cancellationToken)
    {
        var foodFacilities = await repository.GetByApplicant(query.Applicant);
        
        return foodFacilities is null || foodFacilities.Count is 0
            ? Error.NotFound(description: "No food trucks or carts found")
            : foodFacilities;
    }
}
