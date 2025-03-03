using FluentValidation;
using PhrasalVerbs.Application.Models;

namespace PhrasalVerbs.Application.Validators;

public class TranslationValidator : AbstractValidator<Translation>
{
    public TranslationValidator()
    {
        RuleFor(pv => pv.Language)
            .NotEmpty()
            .MaximumLength(2);

        RuleFor(pv => pv.Verb)
            .NotEmpty()
            .MaximumLength(100);
    }
}
