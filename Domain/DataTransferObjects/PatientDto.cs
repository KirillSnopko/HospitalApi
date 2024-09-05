using Domain.Enums;


namespace Domain.DataTransferObjects;

public class PatientDto
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public string Address { get; set; }

    public DateTime DateOfBirth { get; set; }

    public Gender Gender { get; set; }

    public int SectorNumber { get; set; }
}
