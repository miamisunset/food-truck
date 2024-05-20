using ErrorOr;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

public record GetAllQuery : IRequest<ErrorOr<List<MobileFoodFacility>>>;
