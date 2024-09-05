using JetBrains.Annotations;
using MediatR;
using Persistence.Repositories.Interfaces;
using Shared.Exceptions;

namespace Application.ApiCommandHandlers.Patients.Handlers.Delete;

[UsedImplicitly]
public sealed class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
{
    private readonly IPatientRepository _repository;

    public DeletePatientCommandHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);

        if (patient is null)
        {
            throw new HospitalNotFoundException("Doctor not found");
        }

        patient.SoftDelete();
        await _repository.UpdateAsync(patient);
    }
}
