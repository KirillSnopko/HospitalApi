using Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.ApiCommandHandlers.Patients.Handlers.Add;

public sealed record AddPatientCommand : IRequest<long>
{
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
