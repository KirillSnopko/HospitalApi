using FluentValidation;

namespace Application.ApiCommandHandlers.Doctors.Handlers.Update;

public sealed class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
{
    public UpdateDoctorCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.FIO).NotEmpty();
        RuleFor(x => x.SpecializationId).NotEmpty();
    }
}
