using FoodTruck.Application.MobileFoodFacilities.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruck.Api.Controllers;

[Route("{controller}")]
public class MobileFoodFacilitiesController(ISender mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllMobileFoodFacilities()
    {
        await mediator.Send(new GetAllMobileFoodFacilitiesQuery());
        return Ok();
    }
}
