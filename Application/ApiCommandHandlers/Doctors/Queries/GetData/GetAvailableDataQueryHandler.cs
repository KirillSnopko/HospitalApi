using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;

namespace Application.ApiCommandHandlers.Doctors.Queries.GetData;

public sealed class GetAvailableDataQueryHandler : IRequestHandler<GetAvailableDataQuery, GetAvailableDataQueryResponse>
{
    private readonly ISpecializationRepository _specializationRepository;
    private readonly ISectorRepository _sectorRepository;
    private readonly ICabinetRepository _cabinetRepository;

    public GetAvailableDataQueryHandler(ISpecializationRepository specializationRepository, ISectorRepository sectorRepository, ICabinetRepository cabinetRepository)
    {
        _specializationRepository = specializationRepository;
        _sectorRepository = sectorRepository;
        _cabinetRepository = cabinetRepository;
    }

    public async Task<GetAvailableDataQueryResponse> Handle(GetAvailableDataQuery request, CancellationToken cancellationToken)
    {
        return new GetAvailableDataQueryResponse
        {
            Specialization = await _specializationRepository.Queryable().ToDictionaryAsync(x => x.Id, x => x.Name, cancellationToken),
            Sectors = await _sectorRepository.Queryable().ToDictionaryAsync(x => x.Id, x => x.Number, cancellationToken),
            Cabinets = await _cabinetRepository.Queryable().ToDictionaryAsync(x => x.Id, x => x.Number, cancellationToken)
        };
    }
}
