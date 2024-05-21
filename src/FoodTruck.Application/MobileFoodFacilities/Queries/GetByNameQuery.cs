using ErrorOr;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

public record GetByNameQuery(string Applicant) : IRequest<ErrorOr<List<MobileFoodFacility>>>;
