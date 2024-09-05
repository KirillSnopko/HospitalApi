using FluentValidation;

namespace Application.ApiCommandHandlers.Patients.Handlers.Update;

public sealed class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
{
    public UpdatePatientCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Patronymic).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.SectorId).NotEmpty().NotEqual(0);
        RuleFor(x => x.Id).NotEmpty().NotEqual(0);
    }
}
