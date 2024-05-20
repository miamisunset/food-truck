using ErrorOr;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

public record GetByNameQuery(string applicant) : IRequest<ErrorOr<List<MobileFoodFacility>>>;
