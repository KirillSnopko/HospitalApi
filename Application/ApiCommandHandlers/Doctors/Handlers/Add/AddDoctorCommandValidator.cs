using FluentValidation;

namespace Application.ApiCommandHandlers.Doctors.Handlers.Add;

public sealed class AddDoctorCommandValidator : AbstractValidator<AddDoctorCommand>
{
    public AddDoctorCommandValidator()
    {
        RuleFor(x => x.FIO).NotEmpty();
        RuleFor(x => x.SpecializationId).NotEmpty();
    }
}
