namespace Application.ApiCommandHandlers.Doctors.Queries.GetData;

public sealed record GetAvailableDataQueryResponse
{
    public Dictionary<long, string> Specialization { get; set; }
    public Dictionary<long, int> Sectors { get; set; }
    public Dictionary<long, int> Cabinets { get; set; }
}
