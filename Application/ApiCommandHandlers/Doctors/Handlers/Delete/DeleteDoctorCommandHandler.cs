using JetBrains.Annotations;
using MediatR;
using Persistence.Repositories.Interfaces;


namespace Application.ApiCommandHandlers.Doctors.Handlers.Delete
{
    [UsedImplicitly]
    public sealed class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
    {
        private readonly IDoctorRepository _repository;

        public DeleteDoctorCommandHandler(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _repository.GetByIdAsync(request.Id);

            if (doctor is null)
            {
                throw new ArgumentNullException("Doctor not found");
            }

            doctor.SoftDelete();
            await _repository.UpdateAsync(doctor);
        }
    }
}
