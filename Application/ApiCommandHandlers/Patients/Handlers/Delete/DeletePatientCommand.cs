using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.ApiCommandHandlers.Patients.Handlers.Delete;

public sealed record DeletePatientCommand([Required] long Id) : IRequest
{
}
