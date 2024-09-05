using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.ApiCommandHandlers.Doctors.Handlers.Add;

public sealed record AddDoctorCommand : IRequest<long>
{
    [Required]
    public string FIO { get; set; }

    [Required]
    public long SpecializationId { get; set; }

    [Required]
    public long CabinetId { get; set; }

    [Required]
    public long SectorId { get; set; }
}
