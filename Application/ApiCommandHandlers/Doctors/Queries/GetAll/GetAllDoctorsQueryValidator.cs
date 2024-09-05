using Application.ApiCommandHandlers.Validation;
using FluentValidation;

namespace Application.ApiCommandHandlers.Doctors.Queries.GetAll;

public sealed class GetAllDoctorsQueryValidator : AbstractValidator<GetAllDoctorsQuery>
{
    public GetAllDoctorsQueryValidator()
    {
        RuleFor(x => x.PaginationParams)
            .NotNull().SetValidator(new PaginationValidator());
    }
}
