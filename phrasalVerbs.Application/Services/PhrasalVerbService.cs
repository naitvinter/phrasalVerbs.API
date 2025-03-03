using FluentValidation;
using PhrasalVerbs.Application.Models;
using PhrasalVerbs.Application.Repositories;

namespace PhrasalVerbs.Application.Services;

public class PhrasalVerbService : IPhrasalVerbsService
{
    private readonly IPhrasalVerbsRepository _repository;
    private readonly IValidator<PhrasalVerb> _phrasalVerbValidator;
    private readonly IValidator<Translation> _translationValidator;

    public PhrasalVerbService(IPhrasalVerbsRepository repository, IValidator<PhrasalVerb> phrasalVerbValidator, IValidator<Translation> translationValidator)
    {
        _repository = repository;
        _phrasalVerbValidator = phrasalVerbValidator;
        _translationValidator = translationValidator;
    }

    public async Task<PhrasalVerb?> CreateAsync(PhrasalVerb phrasalVerb, CancellationToken token = default)
    {
        await _phrasalVerbValidator.ValidateAndThrowAsync(phrasalVerb, token);

        foreach (Translation translation in phrasalVerb.Translations)
            await _translationValidator.ValidateAndThrowAsync(translation, token);

        return await _repository.CreateAsync(phrasalVerb, token);
    }

    public async Task<PhrasalVerb?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _repository.GetByIdAsync(id, token);
    }

    public async Task<PhrasalVerb?> GetBySlugAsync(string slug, CancellationToken token = default)
    {
        return await _repository.GetBySlugAsync(slug, token);
    }

    public async Task<IEnumerable<PhrasalVerb>> GetAllAsync(CancellationToken token = default)
    {
        return await _repository.GetAllAsync(token);
    }

    public async Task<PhrasalVerb?> UpdateAsync(PhrasalVerb phrasalVerb, CancellationToken token = default)
    {
        await _phrasalVerbValidator.ValidateAndThrowAsync(phrasalVerb, token);

        foreach (Translation translation in phrasalVerb.Translations)
            await _translationValidator.ValidateAndThrowAsync(translation, token);

        var verbExists = await _repository.ExistByIdAsync(phrasalVerb.Id, token);

        if(!verbExists)
            return null;

        await _repository.UpdateAsync(phrasalVerb, token);
        return phrasalVerb;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        var verbExists = await _repository.ExistByIdAsync(id, token);

        if(verbExists)
            return await _repository.DeleteByIdAsync(id, token);
        else
            return false;
    }
}
