using Domain.DataTransferObjects;
using MediatR;
using Shared.Models;

namespace Application.ApiCommandHandlers.Patients.Queries.GetAll;

public sealed record GetAllPatientsQuery : IRequest<List<PatientDto>>
{
    public PaginationParams PaginationParams { get; set; }

    public bool SortByNameAsc { get; set; }
}
