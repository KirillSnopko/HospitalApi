using Application.ApiCommandHandlers.Doctors.GetAll;
using Domain.DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace HospitalApi.Controllers;

[ApiController]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class DoctorController : Controller
{
    private readonly IMediator _mediator;

    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("search", Name = "SearchDoctors")]
    [ProducesResponseType(typeof(List<DoctorDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> SearchMeetings([FromBody] GetAllDoctorsCommand request) => Ok(await _mediator.Send(request));
}
