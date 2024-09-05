using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DataTransferObjects;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;

namespace Application.ApiCommandHandlers.Patients.Queries.GetAll;

[UsedImplicitly]
public sealed class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, List<PatientDto>>
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public GetAllPatientsQueryHandler(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<List<PatientDto>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        var queryable = _repository.Queryable();

        if (request.SortByNameAsc)
        {
            queryable = queryable.OrderBy(x => x.LastName);
        }
        else
        {
            queryable = queryable.OrderByDescending(x => x.LastName);
        }

        return queryable.Skip(request.PaginationParams.Offset)
                        .Take(request.PaginationParams.Limit)
                        .ProjectTo<PatientDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();
    }
}
