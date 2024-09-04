using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.ApiCommandHandlers.Doctors.Handlers.Update;

public sealed record UpdateDoctorCommand : IRequest
{
    [Required]
    public long Id { get; set; }

    [Required]
    public string FIO { get; set; }

    [Required]
    public long SpecializationId { get; set; }

    public long CabinetId { get; set; }

    public long SectorId { get; set; }
}
