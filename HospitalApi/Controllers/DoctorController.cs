using Application.ApiCommandHandlers.Doctors.Handlers.Add;
using Application.ApiCommandHandlers.Doctors.Handlers.Delete;
using Application.ApiCommandHandlers.Doctors.Handlers.Update;
using Application.ApiCommandHandlers.Doctors.Queries.GetAll;
using Application.ApiCommandHandlers.Doctors.Queries.GetById;
using Application.ApiCommandHandlers.Doctors.Queries.GetData;
using Domain.DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace HospitalApi.Controllers;

[ApiController]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/doctors")]
public class DoctorController : Controller
{
    private readonly IMediator _mediator;

    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("search", Name = "SearchDoctors")]
    [ProducesResponseType(typeof(List<DoctorDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> SearchMeetings([FromBody] GetAllDoctorsQuery request) => Ok(await _mediator.Send(request));

    [HttpGet("available-data", Name = "Available data")]
    [ProducesResponseType(typeof(GetAvailableDataQueryResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult> AvailableData() => Ok(await _mediator.Send(new GetAvailableDataQuery()));

    [HttpGet("id:long", Name = "Doctor by id")]
    [ProducesResponseType(typeof(DoctorDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetById(long id) => Ok(await _mediator.Send(new GetDoctorByIdQuery(id)));

    [HttpPost(Name = "Add doctor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Add(AddDoctorCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut(Name = "Update doctor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Update(UpdateDoctorCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete(Name = "Delete doctor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Update(DeleteDoctorCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}
