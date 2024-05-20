using ErrorOr;
using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

public class GetAllMobileFoodFacilitiesQueryHandler(
    IMobileFoodFacilityRepository repository) 
    : IRequestHandler<GetAllMobileFoodFacilitiesQuery, ErrorOr<List<MobileFoodFacility>>>
{
    public async Task<ErrorOr<List<MobileFoodFacility>>> Handle(
        GetAllMobileFoodFacilitiesQuery query, 
        CancellationToken cancellationToken)
    {
        var foodFacilities = await repository.ListAsync();

        return foodFacilities is null || foodFacilities.Count is 0
            ? Error.NotFound(description: "No food trucks or carts found")
            : foodFacilities;
    }
}
