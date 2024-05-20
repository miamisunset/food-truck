using ErrorOr;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

public class GetAllMobileFoodFacilitiesQueryHandler 
    : IRequestHandler<GetAllMobileFoodFacilitiesQuery, ErrorOr<List<MobileFoodFacility>>>
{
    public Task<ErrorOr<List<MobileFoodFacility>>> Handle(
        GetAllMobileFoodFacilitiesQuery query, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
