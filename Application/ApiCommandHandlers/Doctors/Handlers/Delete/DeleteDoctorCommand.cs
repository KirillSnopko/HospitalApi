using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.ApiCommandHandlers.Doctors.Handlers.Delete;

public sealed record DeleteDoctorCommand([Required] long Id) : IRequest
{
}
