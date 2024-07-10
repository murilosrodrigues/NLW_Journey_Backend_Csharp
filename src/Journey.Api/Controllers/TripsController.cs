using Journey.Application.UseCases.Trips.Delete;
using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    [HttpPost]

    [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
    {
            var useCase = new RegisterTripUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
    }

    [HttpGet]

    [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var usecase = new GetAllTripsUseCase();

        var result = usecase.Execute();

        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
            var useCase = new GetTripByIdUseCase();
            var response = useCase.Execute(id);
            return Ok();
      
    }


    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var useCase = new DeleteTripByIdUseCase();

       useCase.Execute(id);
        return NoContent();
    }

}
