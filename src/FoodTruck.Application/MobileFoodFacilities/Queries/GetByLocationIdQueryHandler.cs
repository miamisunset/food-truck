using ErrorOr;
using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

public class GetByLocationIdQueryHandler(
    IMobileFoodFacilityRepository repository)
    : IRequestHandler<GetByLocationIdQuery, ErrorOr<MobileFoodFacility>>
{
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
