using Application.ApiCommandHandlers.Validation;
using FluentValidation;

namespace Application.ApiCommandHandlers.Patients.Queries.GetAll;

public sealed class GetAllPatientsQueryValidator : AbstractValidator<GetAllPatientsQuery>
{
    public GetAllPatientsQueryValidator()
    {
        RuleFor(x => x.PaginationParams)
            .NotNull().SetValidator(new PaginationValidator());
    }
}
