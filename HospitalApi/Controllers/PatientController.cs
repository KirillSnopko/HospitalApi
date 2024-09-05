using Application.ApiCommandHandlers.Patients.Handlers.Add;
using Application.ApiCommandHandlers.Patients.Handlers.Delete;
using Application.ApiCommandHandlers.Patients.Handlers.Update;
using Application.ApiCommandHandlers.Patients.Queries.GetAll;
using Application.ApiCommandHandlers.Patients.Queries.GetById;
using Domain.DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace HospitalApi.Controllers;

[ApiController]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/patients")]
public class PatientController : Controller
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("all", Name = "All patients")]
    [ProducesResponseType(typeof(List<PatientDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> All([FromBody] GetAllPatientsQuery request) => Ok(await _mediator.Send(request));

    [HttpGet("id:long", Name = "Patient by id")]
    [ProducesResponseType(typeof(PatientEditDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetById(long id) => Ok(await _mediator.Send(new GetPatientByIdQuery(id)));

    [HttpPost(Name = "Add patient")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult> Add(AddPatientCommand command) => Ok(await _mediator.Send(command));

    [HttpPut(Name = "Update patient")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(UpdatePatientCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete(Name = "Delete patient")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(DeletePatientCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}
