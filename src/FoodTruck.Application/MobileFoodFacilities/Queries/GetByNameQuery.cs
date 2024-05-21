using ErrorOr;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

/// <summary>
/// Represents a query to retrieve a list of mobile food facilities by applicant name.
/// </summary>
public record GetByNameQuery(string Applicant) : IRequest<ErrorOr<List<MobileFoodFacility>>>;
