using System.ComponentModel.DataAnnotations;

namespace Domain.DataTransferObjects;

public record DoctorEditDto
{
    [Required]
    public long Id { get; set; }

    [Required]
    public string FIO { get; set; }

    [Required]
    public long CabinetId { get; set; }

    [Required]
    public long SpecializationId { get; set; }

    [Required]
    public long SectorId { get; set; }
}
