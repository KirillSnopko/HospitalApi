using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.ApiCommandHandlers.Doctors.Handlers.Add;

public sealed record AddDoctorCommand : IRequest
{
    [Required]
    public string FIO { get; set; }

    [Required]
    public long SpecializationId { get; set; }

    public long CabinetId { get; set; }

    public long SectorId { get; set; }
}
