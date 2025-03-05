using FluentValidation;
using PhrasalVerbs.Application.Models;

namespace PhrasalVerbs.Application.Validators;

public class GetAllPhersalVerbsOptionsValidator : AbstractValidator<GetAllPhersalVerbsOptions>
{
    public GetAllPhersalVerbsOptionsValidator()
    {
        RuleFor(x => x.Verb)
            .MaximumLength(50)
            .WithMessage("Verb length must be less than 20 characters.");
        RuleFor(x => x.Particle)
            .MaximumLength(50)
            .WithMessage("Particle length must be less than 20 characters.");
        RuleFor(x => x.SortField)
            .Must(x => x is null || x.ToLower() == "verb")
            .WithMessage("Sort field must be null or 'verb'.");
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page must be greater than or equal to 1.");
        RuleFor(x => x.PageSize)
            .InclusiveBetween(1,20)
            .WithMessage("Page size must be between 1 and 20.");
    }
}
