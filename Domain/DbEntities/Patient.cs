using Domain.Enums;

namespace Domain.DbEntities;

public class Patient : BaseEntity<long>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public string Address { get; set; }

    public DateTime DateOfBirth { get; set; }

    public Gender Gender { get; set; }

    public long SectorId { get; set; }

    public virtual Sector Sector { get; set; }
}
