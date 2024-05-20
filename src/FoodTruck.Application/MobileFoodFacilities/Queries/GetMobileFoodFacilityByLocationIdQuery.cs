using ErrorOr;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

public record GetMobileFoodFacilityByLocationIdQuery(int locationId) : IRequest<ErrorOr<MobileFoodFacility>>;
