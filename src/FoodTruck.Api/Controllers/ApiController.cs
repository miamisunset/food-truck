using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoodTruck.Api.Controllers;

/// <summary>
/// Represents the base controller for the API.
/// </summary>
[ApiController]
public class ApiController : ControllerBase
{
    /// <summary>
    /// Generates a problem response based on a list of errors.
    /// </summary>
    /// <param name="errors">The list of errors.</param>
    /// <returns>An <see cref="IActionResult"/> representing the problem response.</returns>
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0) return Problem();

        return errors.All(error => error.Type == ErrorType.Validation) 
            ? ValidationProblem(errors) 
            : Problem(errors[0]);
    }

    /// <summary>
    /// Generates a problem response based on a list of errors.
    /// </summary>
    /// <param name="error">Possible errors.</param>
    /// <returns>An <see cref="IActionResult"/> representing the problem response.</returns>
    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };

        return Problem(statusCode: statusCode, detail: error.Description);
    }

    /// <summary>
    /// Generates a validation problem response based on a list of errors.
    /// </summary>
    /// <param name="errors">The list of errors.</param>
    /// <returns>An <see cref="IActionResult"/> representing the validation problem response.</returns>
    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(
                error.Code,
                error.Description);
        }

        return ValidationProblem(modelStateDictionary);
    }
}
