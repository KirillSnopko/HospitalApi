using Domain.DbEntities;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;
using Shared.Exceptions;

namespace Application.ApiCommandHandlers.Patients.Handlers.Add;

[UsedImplicitly]
public sealed class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, long>
{
    private readonly IPatientRepository _repository;
    private readonly ISectorRepository _sectorRepository;

    public AddPatientCommandHandler(IPatientRepository repository, ISectorRepository sectorRepository)
    {
        _repository = repository;
        _sectorRepository = sectorRepository;
    }

    public async Task<long> Handle(AddPatientCommand request, CancellationToken cancellationToken)
    {
        if (await _repository.Queryable().AnyAsync(x => x.FirstName == request.FirstName && x.LastName == request.LastName && x.Patronymic == request.Patronymic))
        {
            throw new HospitalDuplicateException("Such patient already exists");
        }

        if (await _sectorRepository.GetByIdAsync(request.SectorId) is null)
        {
            throw new HospitalNotFoundException($"Sector with Id={request.SectorId} not found");
        }

        var patient = new Patient
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Patronymic = request.Patronymic,
            Address = request.Address,
            Gender = request.Gender,
            DateOfBirth = request.DateOfBirth,
            SectorId = request.SectorId,
        };

        await _repository.CreateAsync(patient);

        return patient.Id;
    }
}
