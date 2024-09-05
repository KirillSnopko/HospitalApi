using JetBrains.Annotations;
using MediatR;
using Persistence.Repositories.Interfaces;
using Shared.Exceptions;

namespace Application.ApiCommandHandlers.Doctors.Handlers.Update;

[UsedImplicitly]
public sealed class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand>
{
    private readonly IDoctorRepository _repository;
    private readonly ISpecializationRepository _specificationRepository;
    private readonly ISectorRepository _sectorRepository;
    private readonly ICabinetRepository _cabinetRepository;

    public UpdateDoctorCommandHandler(IDoctorRepository repository, ISpecializationRepository specificationRepository, ISectorRepository sectorRepository, ICabinetRepository cabinetRepository)
    {
        _repository = repository;
        _specificationRepository = specificationRepository;
        _sectorRepository = sectorRepository;
        _cabinetRepository = cabinetRepository;
    }

    public async Task Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);

        if (doctor is null)
        {
            throw new HospitalNotFoundException("Doctor not found");
        }

        if (doctor.CabinetId != request.CabinetId && await _cabinetRepository.GetByIdAsync(request.CabinetId) is null)
        {
            throw new HospitalNotFoundException($"Cabinet with Id={request.CabinetId} not found");
        }

        if (doctor.SectorId != request.SectorId && await _sectorRepository.GetByIdAsync(request.SectorId) is null)
        {
            throw new HospitalNotFoundException($"Sector with Id={request.SectorId} not found");
        }

        if (doctor.SpecializationId != request.SpecializationId && await _specificationRepository.GetByIdAsync(request.SpecializationId) is null)
        {
            throw new HospitalNotFoundException($"Specialization with Id={request.SpecializationId} not found");
        }

        doctor.FIO = request.FIO;
        doctor.SpecializationId = request.SpecializationId;
        doctor.SectorId = request.SectorId;
        doctor.CabinetId = request.CabinetId;

        await _repository.UpdateAsync(doctor);
    }
}
