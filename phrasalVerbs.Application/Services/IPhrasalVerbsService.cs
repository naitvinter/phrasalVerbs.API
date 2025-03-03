using PhrasalVerbs.Application.Models;

namespace PhrasalVerbs.Application.Services;

public interface IPhrasalVerbsService
{
    Task<PhrasalVerb?> CreateAsync(PhrasalVerb phrasalVerb, CancellationToken token = default);

    Task<PhrasalVerb?> GetByIdAsync(Guid id, CancellationToken token = default);

    Task<PhrasalVerb?> GetBySlugAsync(string slug, CancellationToken token = default);

    Task<IEnumerable<PhrasalVerb>> GetAllAsync(CancellationToken token = default);

    Task<PhrasalVerb?> UpdateAsync(PhrasalVerb phrasalVerb, CancellationToken token = default);

    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
}
