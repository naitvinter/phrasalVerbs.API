using PhrasalVerbs.Application.Models;
using PhrasalVerbs.Contracts.Requests;
using PhrasalVerbs.Contracts.Responses;

namespace PhrasalVerbs.API.Mapping;

public static class ContractMapping
{
    public static PhrasalVerb MapToPhrasalVerb(this CreatePhrasalVerbRequest request)
    {
        return new PhrasalVerb
        {
            Id = Guid.NewGuid(),
            Verb = request.Verb,
            Translations = request.Translations.Select(t => new Translation
            {
                Id = Guid.NewGuid(),
                Language = t.Language,
                Verb = t.Verb
            }).ToList()
        };
    }

    public static PhrasalVerb MapToPhrasalVerb(this UpdatePhrasalVerbRequest request, Guid id)
    {
        return new PhrasalVerb
        {
            Id = id,
            Verb = request.Verb,
            Translations = request.Translations.Select(t => new Translation
            {
                Id = Guid.NewGuid(),
                Language = t.Language,
                Verb = t.Verb
            }).ToList()
        };
    }

    public static PhrasalVerbResponse MapToPhrasalVerbResponse(this PhrasalVerb phrasalVerb)
    {
        return new PhrasalVerbResponse
        {
            Id = phrasalVerb.Id,
            Verb = phrasalVerb.Verb,
            Translations = phrasalVerb.Translations.Select(t => new TranslationResponse
            {
                Id = t.Id,
                Language = t.Language,
                Verb = t.Verb
            }).ToList()
        };
    }

    public static PhrasalVerbsResponse MapToPhrasalVerbsResponse(this IEnumerable<PhrasalVerb> phrasalVerbs)
    {
        return new PhrasalVerbsResponse
        {
            Items = phrasalVerbs.Select(MapToPhrasalVerbResponse).ToList()
        };
    }
}
