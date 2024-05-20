using ErrorOr;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

public record GetByLocationIdQuery(int LocationId) : IRequest<ErrorOr<MobileFoodFacility>>;
