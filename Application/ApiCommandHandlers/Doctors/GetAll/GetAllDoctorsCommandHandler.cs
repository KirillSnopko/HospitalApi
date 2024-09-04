using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DataTransferObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;

namespace Application.ApiCommandHandlers.Doctors.GetAll;

public sealed class GetAllDoctorsCommandHandler : IRequestHandler<GetAllDoctorsCommand, List<DoctorDto>>
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;

    public GetAllDoctorsCommandHandler(IDoctorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<List<DoctorDto>> Handle(GetAllDoctorsCommand request, CancellationToken cancellationToken)
    {
        var queryable = _repository.Queryable();

        if (request.SortByNameAsc)
        {
            queryable = queryable.OrderBy(x => x.FIO);
        }
        else
        {
            queryable = queryable.OrderByDescending(x => x.FIO);
        }

        return queryable.Skip(request.PaginationParams.Offset)
                        .Take(request.PaginationParams.Limit)
                        .ProjectTo<DoctorDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();
    }
}
