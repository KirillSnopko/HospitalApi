using Domain.DbEntities;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;

namespace Application.ApiCommandHandlers.Doctors.Handlers.Add;

[UsedImplicitly]
public sealed class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommand>
{
    private readonly IDoctorRepository _repository;

    public AddDoctorCommandHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(AddDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.Queryable().FirstOrDefaultAsync(x => x.FIO == request.FIO);

        if (doctor is not null)
        {
            throw new ArgumentException("Duplicate");
        }

        doctor = new Doctor
        {
            FIO = request.FIO,
            SpecializationId = request.SpecializationId,
            SectorId = request.SectorId,
            CabinetId = request.CabinetId
        };

        await _repository.CreateAsync(doctor);
    }
}
