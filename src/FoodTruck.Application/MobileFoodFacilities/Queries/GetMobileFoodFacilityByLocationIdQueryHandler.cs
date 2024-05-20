using ErrorOr;
using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

public class GetMobileFoodFacilityByLocationIdQueryHandler(
    IMobileFoodFacilityRepository repository)
    : IRequestHandler<GetMobileFoodFacilityByLocationIdQuery, ErrorOr<MobileFoodFacility>>
{
    public async Task<ErrorOr<MobileFoodFacility>> Handle(
        GetMobileFoodFacilityByLocationIdQuery query, 
        CancellationToken cancellationToken)
    {
        var foodFacility = await repository.GetByLocationId(query.locationId);

        return foodFacility is null
            ? Error.NotFound($"{query.locationId} mobile food facility not found")
            : foodFacility;
    }
}
