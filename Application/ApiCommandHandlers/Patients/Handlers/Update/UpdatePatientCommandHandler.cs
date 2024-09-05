using Domain.DbEntities;
using JetBrains.Annotations;
using MediatR;
using Persistence.Repositories.Implementations;
using Persistence.Repositories.Interfaces;
using Shared.Exceptions;

namespace Application.ApiCommandHandlers.Patients.Handlers.Update;

[UsedImplicitly]
public sealed class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
{
    private readonly IPatientRepository _repository;
    private readonly ISectorRepository _sectorRepository;

    public UpdatePatientCommandHandler(IPatientRepository repository, ISectorRepository sectorRepository)
    {
        _repository = repository;
        _sectorRepository = sectorRepository;
    }

    public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);

        if (patient is null)
        {
            throw new HospitalNotFoundException("Patient not found");
        }

        if (patient.SectorId != request.SectorId && await _sectorRepository.GetByIdAsync(request.SectorId) is null)
        {
            throw new HospitalNotFoundException($"Sector with Id={request.SectorId} not found");
        }


        patient.FirstName = request.FirstName;
        patient.LastName = request.LastName;
        patient.Patronymic = request.Patronymic;
        patient.Address = request.Address;
        patient.DateOfBirth = request.DateOfBirth;
        patient.Gender = request.Gender;
        patient.SectorId = request.SectorId;

        await _repository.UpdateAsync(patient);
    }
}
