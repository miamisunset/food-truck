using ErrorOr;
using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

public class GetByNameQueryHandler(
    IMobileFoodFacilityRepository repository) 
    : IRequestHandler<GetByNameQuery, ErrorOr<List<MobileFoodFacility>>>
{
    public async Task<ErrorOr<List<MobileFoodFacility>>> Handle(
        GetByNameQuery query, 
        CancellationToken cancellationToken)
    {
        var foodFacilities = await repository.GetByApplicant(query.applicant);
        
        return foodFacilities is null || foodFacilities.Count is 0
            ? Error.NotFound(description: "No food trucks or carts found")
            : foodFacilities;
    }
}
