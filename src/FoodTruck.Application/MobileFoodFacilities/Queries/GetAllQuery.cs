using ErrorOr;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

/// <summary>
/// Represents a query to retrieve a list of all mobile food facilities.
/// </summary>
public record GetAllQuery(
    int Page,
    int Size) 
    : IRequest<ErrorOr<List<MobileFoodFacility>>>;
