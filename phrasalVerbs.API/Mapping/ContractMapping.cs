using Microsoft.Data.SqlClient;
using PhrasalVerbs.Application.Models;
using PhrasalVerbs.Contracts.Requests;
using PhrasalVerbs.Contracts.Responses;

namespace PhrasalVerbs.API.Mapping;

public static class ContractMapping
{
    public static PhrasalVerb MapToPhrasalVerb(this CreatePhrasalVerbRequest request)
    {
        var _phrasalVerb = new PhrasalVerb
        {
            Id = Guid.NewGuid(),
            Verb = request.Verb,
        };

        var _translations = request.Translations.Select(t => new Translation
        {
            Id = Guid.NewGuid(),
            PhrasalVerbId = _phrasalVerb.Id,
            Language = t.Language,
            Verb = t.Verb
        }).ToList();

        _phrasalVerb.Translations = _translations;

        return _phrasalVerb;
    }

    public static PhrasalVerb MapToPhrasalVerb(this UpdatePhrasalVerbRequest request, Guid id)
    {
        var _phrasalVerb = new PhrasalVerb
        {
            Id = id,
            Verb = request.Verb,
        };

        var _translations = request.Translations.Select(t => new Translation
        {
            Id = Guid.NewGuid(),
            PhrasalVerbId = _phrasalVerb.Id,
            Language = t.Language,
            Verb = t.Verb
        }).ToList();

        _phrasalVerb.Translations = _translations;

        return _phrasalVerb;
    }

    public static PhrasalVerbResponse MapToPhrasalVerbResponse(this PhrasalVerb phrasalVerb)
    {
        return new PhrasalVerbResponse
        {
            Id = phrasalVerb.Id,
            Slug = phrasalVerb.Slug,
            Verb = phrasalVerb.Verb,
            Translations = phrasalVerb.Translations.Select(t => new TranslationResponse
            {
                Id = t.Id,
                Language = t.Language,
                Verb = t.Verb
            }).ToList()
        };
    }

    public static PhrasalVerbsResponse MapToPhrasalVerbsResponse(this IEnumerable<PhrasalVerb> phrasalVerbs, int page, int pageSize, int verbsCount)
    {
        return new PhrasalVerbsResponse
        {
            Items = phrasalVerbs.Select(MapToPhrasalVerbResponse).ToList(),
            Page = page,
            PageSize = pageSize,
            Total = verbsCount
        };
    }
    
    public static GetAllPhersalVerbsOptions MapToOptions(this GetAllPhrasalVerbsRequest request)
    {
        return new GetAllPhersalVerbsOptions
        {
            Verb = request.Verb, 
            Particle = request.Particle,
            SortField = request.SortBy?.Trim('+', '-'),
            SortOrder = request.SortBy is null ? SortOrder.Unspecified :
                request.SortBy?.StartsWith('-') == true ? SortOrder.Descending : SortOrder.Ascending,
            Page = request.Page.GetValueOrDefault(PagedRequest.DefaultPage ),
            PageSize = request.PageSize.GetValueOrDefault(PagedRequest.DefaultPageSize)
        };
    }
}
