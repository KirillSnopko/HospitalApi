using Domain.DataTransferObjects;
using MediatR;

namespace Application.ApiCommandHandlers.Doctors.Handlers.Update;

public sealed record UpdateDoctorCommand : DoctorEditDto, IRequest { }
