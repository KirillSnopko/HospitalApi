using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.DataTransferObjects;

public record PatientEditDto
{
    [Required]
    public long Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Patronymic { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    public Gender Gender { get; set; }

    [Required]
    public long SectorId { get; set; }
}
