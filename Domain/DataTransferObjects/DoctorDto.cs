namespace Domain.DataTransferObjects;

public class DoctorDto
{
    public long Id { get; set; }

    public string FIO { get; set; }

    public string Specialization { get; set; }

    public int CabinetNumber { get; set; }

    public int SectorNumber { get; set; }
}
