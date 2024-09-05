using Domain.DataTransferObjects;
using MediatR;

namespace Application.ApiCommandHandlers.Patients.Handlers.Update;

public sealed record UpdatePatientCommand : PatientEditDto, IRequest { }
