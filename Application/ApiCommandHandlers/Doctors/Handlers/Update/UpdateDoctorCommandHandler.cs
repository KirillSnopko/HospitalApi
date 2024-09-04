using JetBrains.Annotations;
using MediatR;
using Persistence.Repositories.Interfaces;


namespace Application.ApiCommandHandlers.Doctors.Handlers.Update;

[UsedImplicitly]
public sealed class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand>
{
    private readonly IDoctorRepository _repository;

    public UpdateDoctorCommandHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);

        if (doctor is null)
        {
            throw new ArgumentNullException("Doctor not found");
        }

        doctor.FIO = request.FIO;
        doctor.SpecializationId = request.SpecializationId;
        doctor.SectorId = request.SectorId;
        doctor.CabinetId = request.CabinetId;

        await _repository.UpdateAsync(doctor);
    }
}
