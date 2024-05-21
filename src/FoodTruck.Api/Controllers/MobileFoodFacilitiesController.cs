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
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MobileFoodFacilitiesResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllMobileFoodFacilities() => 
        await GetMobileFoodFacilitiesList(new GetAllQuery());

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

    private static MobileFoodFacilitiesResponse ToResponseDto(MobileFoodFacility foodFacility) =>
        new(foodFacility.LocationId, 
            foodFacility.Applicant,
            ToFacilityTypeDto(foodFacility.FacilityType), 
            foodFacility.Cnn, 
            foodFacility.LocationDescription, 
            foodFacility.Address, 
            foodFacility.BlockLot, 
            foodFacility.FoodItems, 
            foodFacility.Longitude, 
            foodFacility.Latitude);

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
