using FoodTruck.Application.MobileFoodFacilities.Queries;
using FoodTruck.Contracts.MobileFoodFacilities;
using FoodTruck.Domain.MobileFoodFacilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainFacilityType = FoodTruck.Domain.MobileFoodFacilities.FacilityType;
using FacilityType = FoodTruck.Contracts.MobileFoodFacilities.FacilityType;

namespace FoodTruck.Api.Controllers;

[Route("[controller]")]
public class MobileFoodFacilitiesController(ISender mediator) : ControllerBase
{
    [HttpGet("{locationId:int}")]
    public async Task<IActionResult> GetMobileFoodFacilityByLocationId(int locationId)
    {
        var result = await mediator
            .Send(new GetByLocationIdQuery(locationId));

        return result.MatchFirst(
            foodFacility => Ok(ToResponseDto(foodFacility)),
            _ => Problem());
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllMobileFoodFacilities()
    {
        var result = await mediator.Send(new GetAllQuery());
        
        return result.MatchFirst(
            foodFacilities =>
            {
                var response = foodFacilities
                    .Select(ToResponseDto)
                    .ToList();

                return Ok(response);
            },
            _ => Problem());
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchByName([FromQuery]string? name)
    {
        if (name is null)
            return Problem(statusCode: StatusCodes.Status400BadRequest);
        
        var result = await mediator.Send(new GetByNameQuery(name));

        return result.MatchFirst(
            foodFacilities =>
            {
                var response = foodFacilities
                    .Select(ToResponseDto)
                    .ToList();

                return Ok(response);
            },
            _ => Problem());
    }

    private static MobileFoodFacilitiesResponse ToResponseDto(MobileFoodFacility foodFacility) =>
        new(foodFacility.LocationId, 
            foodFacility.Applicant,
            ToDto(foodFacility.FacilityType), 
            foodFacility.Cnn, 
            foodFacility.LocationDescription, 
            foodFacility.Address, 
            foodFacility.BlockLot, 
            foodFacility.FoodItems, 
            foodFacility.Longitude, 
            foodFacility.Latitude);

    private static FacilityType ToDto(DomainFacilityType? facilityType)
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
