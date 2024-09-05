using Domain.DbEntities;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;
using Shared.Exceptions;

namespace Application.ApiCommandHandlers.Doctors.Handlers.Add;

[UsedImplicitly]
public sealed class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommand, long>
{
    private readonly IDoctorRepository _repository;
    private readonly ISpecializationRepository _specificationRepository;
    private readonly ISectorRepository _sectorRepository;
    private readonly ICabinetRepository _cabinetRepository;

    public AddDoctorCommandHandler(IDoctorRepository repository, ISpecializationRepository specificationRepository, ISectorRepository sectorRepository, ICabinetRepository cabinetRepository)
    {
        _repository = repository;
        _specificationRepository = specificationRepository;
        _sectorRepository = sectorRepository;
        _cabinetRepository = cabinetRepository;
    }

    public async Task<long> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.Queryable().FirstOrDefaultAsync(x => x.FIO == request.FIO);

        if (doctor is not null)
        {
            throw new HospitalDuplicateException("Such doctor already exists");
        }

        if (await _cabinetRepository.GetByIdAsync(request.CabinetId) is null)
        {
            throw new HospitalNotFoundException($"Cabinet with Id={request.CabinetId} not found");
        }

        if (await _sectorRepository.GetByIdAsync(request.SectorId) is null)
        {
            throw new HospitalNotFoundException($"Sector with Id={request.SectorId} not found");
        }

        if (await _specificationRepository.GetByIdAsync(request.SpecializationId) is null)
        {
            throw new HospitalNotFoundException($"Specialization with Id={request.SpecializationId} not found");
        }

        doctor = new Doctor
        {
            FIO = request.FIO,
            SpecializationId = request.SpecializationId,
            SectorId = request.SectorId,
            CabinetId = request.CabinetId
        };

        await _repository.CreateAsync(doctor);

        return doctor.Id;
    }
}
