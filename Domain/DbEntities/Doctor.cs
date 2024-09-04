namespace Domain.DbEntities;

public class Doctor : BaseEntity<long>
{
    public string FIO { get; set; }

    public long CabinetId { get; set; }

    public virtual Cabinet Cabinet { get; set; }

    public long SpecializationId { get; set; }

    public virtual Specialization Specialization { get; set; }

    public long SectorId { get; set; }

    public virtual Sector Sector { get; set; }
}
