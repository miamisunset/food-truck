using FoodTruck.Application.MobileFoodFacilities.Queries;
using FoodTruck.Contracts.MobileFoodFacilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainFacilityType = FoodTruck.Domain.MobileFoodFacilities.FacilityType;

namespace FoodTruck.Api.Controllers;

[Route("[controller]")]
public class MobileFoodFacilitiesController(ISender mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllMobileFoodFacilities()
    {
        var result = await mediator.Send(new GetAllMobileFoodFacilitiesQuery());
        
        return result.MatchFirst(
            foodFacilities =>
            {
                var response = foodFacilities
                    .Select(foodFacility => new MobileFoodFacilitiesResponse(
                        foodFacility.LocationId, 
                        foodFacility.Applicant,
                        ToDto(foodFacility.FacilityType), 
                        foodFacility.Cnn, 
                        foodFacility.LocationDescription, 
                        foodFacility.Address, 
                        foodFacility.BlockLot, 
                        foodFacility.FoodItems, 
                        foodFacility.Longitude, 
                        foodFacility.Latitude))
                    .ToList();

                return Ok(response);
            },
            _ => Problem());
    }

    private static FacilityType ToDto(DomainFacilityType facilityType) =>
        facilityType.Name switch
        {
            nameof(DomainFacilityType.Unknown) => FacilityType.Unknown,
            nameof(DomainFacilityType.FoodTruck) => FacilityType.Truck,
            nameof(DomainFacilityType.PushCart) => FacilityType.PushCart,
        };
}
