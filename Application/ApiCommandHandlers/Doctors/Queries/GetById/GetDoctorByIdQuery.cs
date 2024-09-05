using Domain.DataTransferObjects;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace Application.ApiCommandHandlers.Doctors.Queries.GetById;

public sealed record GetDoctorByIdQuery([Required] long Id) : IRequest<DoctorEditDto>
{
}
