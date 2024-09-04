using Domain.DataTransferObjects;
using MediatR;
using Shared.Models;

namespace Application.ApiCommandHandlers.Doctors.GetAll;

public sealed record GetAllDoctorsCommand : IRequest<List<DoctorDto>>
{
    public PaginationParams PaginationParams { get; set; }

    public bool SortByNameAsc { get; set; }
}
