using FluentValidation;
using PhrasalVerbs.Application.Models;
using PhrasalVerbs.Application.Repositories;

namespace PhrasalVerbs.Application.Validators;

public class PhrasalVerbValidator : AbstractValidator<PhrasalVerb>
{
    private IPhrasalVerbsRepository _repository;

    public PhrasalVerbValidator(IPhrasalVerbsRepository repository)
    {
        _repository = repository;

        RuleFor(pv => pv.Verb)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(pv => pv.Translations)
            .NotEmpty(); 

        RuleFor(pv => pv.Slug)
            .MustAsync(ValidateSlug)
            .WithMessage("This phrasal verb already exists.");
    }

    private async Task<bool> ValidateSlug(PhrasalVerb verb, string slug, CancellationToken token)
    { 
        var existingVerb = await _repository.GetBySlugAsync(slug);

        if (existingVerb != null)
            return existingVerb.Id == verb.Id;

        return existingVerb == null;
    }
}
