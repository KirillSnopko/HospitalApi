using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DataTransferObjects;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;


namespace Application.ApiCommandHandlers.Patients.Queries.GetById;

[UsedImplicitly]
public sealed class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientEditDto>
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public GetPatientByIdQueryHandler(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<PatientEditDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        return _repository.Queryable().ProjectTo<PatientEditDto>(_mapper.ConfigurationProvider)
                                     .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    }
}
