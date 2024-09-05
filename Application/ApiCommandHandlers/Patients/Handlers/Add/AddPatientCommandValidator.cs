using FluentValidation;

namespace Application.ApiCommandHandlers.Patients.Handlers.Add;

public sealed class AddPatientCommandValidator : AbstractValidator<AddPatientCommand>
{
    public AddPatientCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Patronymic).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.SectorId).NotEmpty().NotEqual(0);
    }
}
