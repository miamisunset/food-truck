using ErrorOr;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

public record GetAllMobileFoodFacilitiesQuery() : IRequest<ErrorOr<List<MobileFoodFacility>>>;
