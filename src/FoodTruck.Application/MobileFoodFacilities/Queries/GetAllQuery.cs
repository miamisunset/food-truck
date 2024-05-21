using ErrorOr;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;

namespace FoodTruck.Application.MobileFoodFacilities.Queries;

/// The `GetAllQuery` class represents a query to retrieve all mobile food facilities.
/// **Usage**
/// ```csharp
/// GetAllQuery query = new GetAllQuery();
/// ```
/// /
public record GetAllQuery : IRequest<ErrorOr<List<MobileFoodFacility>>>;
