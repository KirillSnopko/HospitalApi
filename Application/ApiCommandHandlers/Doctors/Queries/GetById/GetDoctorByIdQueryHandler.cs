using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DataTransferObjects;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;

namespace Application.ApiCommandHandlers.Doctors.Queries.GetById;

[UsedImplicitly]
public sealed class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DoctorEditDto>
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;

    public GetDoctorByIdQueryHandler(IDoctorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<DoctorEditDto> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        return _repository.Queryable().ProjectTo<DoctorEditDto>(_mapper.ConfigurationProvider)
                                      .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    }
}
