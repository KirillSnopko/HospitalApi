using Domain.DataTransferObjects;
using MediatR;
using Shared.Models;

namespace Application.ApiCommandHandlers.Doctors.Queries.GetAll;

public sealed record GetAllDoctorsQuery : IRequest<List<DoctorDto>>
{
    public PaginationParams PaginationParams { get; set; }

    public bool SortByNameAsc { get; set; }
}
