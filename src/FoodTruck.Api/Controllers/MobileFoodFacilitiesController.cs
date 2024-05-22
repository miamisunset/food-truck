using ErrorOr;
using FoodTruck.Application.MobileFoodFacilities.Queries;
using FoodTruck.Contracts.MobileFoodFacilities;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainFacilityType = FoodTruck.Domain.MobileFoodFacilities.FacilityType;
using FacilityType = FoodTruck.Contracts.MobileFoodFacilities.FacilityType;

namespace FoodTruck.Api.Controllers;

[Route("/api/")]
public class MobileFoodFacilitiesController(ISender mediator) : ApiController
{
    /// <summary>
    /// Retrieves a mobile food facility by its location ID.
    /// </summary>
    /// <param name="locationId">The ID of the location to retrieve the mobile food facility for.</param>
    /// <returns>The mobile food facility with the specified location ID, or a problem response if not found.</returns>
    [HttpGet("{locationId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MobileFoodFacilitiesResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMobileFoodFacilityByLocationId(int locationId)
    {
        var result = await mediator
            .Send(new GetByLocationIdQuery(locationId));

        return result.Match(
            foodFacility => Ok(ToResponseDto(foodFacility)),
            Problem);
    }

    /// <summary>
    /// Retrieves a list of all mobile food facilities.
    /// </summary>
    /// <returns>A list of mobile food facilities.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MobileFoodFacilitiesResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllMobileFoodFacilities() => 
        await GetMobileFoodFacilitiesList(new GetAllQuery());

    /// <summary>
    /// Searches mobile food facilities by name.
    /// </summary>
    /// <param name="name">The name to search for.</param>
    /// <returns>A list of mobile food facilities that match the given name.</returns>
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MobileFoodFacilitiesResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SearchByName([FromQuery]string? name)
    {
        const int maxNameLength = 255;
        
        if (name is null || name.Length > maxNameLength)
            return BadRequest($"Name must not be null or longer than {maxNameLength} characters.");

        return await GetMobileFoodFacilitiesList(new GetByNameQuery(name));
    }

    /// <summary>
    /// Retrieves a list of mobile food facilities.
    /// </summary>
    /// <param name="query">The query to fetch the mobile food facilities.</param>
    /// <returns>A list of mobile food facilities.</returns>
    private async Task<IActionResult> GetMobileFoodFacilitiesList(
        IRequest<ErrorOr<List<MobileFoodFacility>>> query)
    {
        var result = await mediator.Send(query);

        return result.Match(
            foodFacilities =>
            {
                var response = foodFacilities
                    .Select(ToResponseDto)
                    .ToList();

                return Ok(response);
            },
            Problem);
    }

    /// <summary>
    /// Converts a domain MobileFoodFacility object to a MobileFoodFacilitiesResponse object.
    /// </summary>
    /// <param name="foodFacility">The domain MobileFoodFacility object to be converted.</param>
    /// <returns>The converted MobileFoodFacilitiesResponse object.</returns>
    private static MobileFoodFacilitiesResponse ToResponseDto(MobileFoodFacility foodFacility) =>
        new(foodFacility.LocationId, 
            foodFacility.Applicant,
            ToFacilityTypeDto(foodFacility.FacilityType), 
            foodFacility.Cnn, 
            foodFacility.LocationDescription, 
            foodFacility.Address, 
            foodFacility.BlockLot, 
            foodFacility.FoodItems,
            Geolocation: new Geolocation(
                foodFacility.Latitude,
                foodFacility.Longitude));

    /// <summary>
    /// Converts a domain FacilityType object to a FacilityType DTO object.
    /// </summary>
    /// <param name="facilityType">The domain FacilityType object to be converted.</param>
    /// <returns>The converted FacilityType DTO object.</returns>
    private static FacilityType ToFacilityTypeDto(DomainFacilityType? facilityType)
    {
        if (facilityType is null) return FacilityType.Unknown;
        
        return facilityType!.Name switch
        {
            "Truck" => FacilityType.Truck,
            "Push Cart" => FacilityType.PushCart,
            _ => FacilityType.Unknown
        };
    }
}
