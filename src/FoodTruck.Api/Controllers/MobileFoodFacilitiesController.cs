using FoodTruck.Application.MobileFoodFacilities.Queries;
using FoodTruck.Contracts.MobileFoodFacilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruck.Api.Controllers;

[Route("{controller}")]
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
                        // TODO: fix conversion error
                        foodFacility.FacilityType, 
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
            error => Problem());
    }
}
