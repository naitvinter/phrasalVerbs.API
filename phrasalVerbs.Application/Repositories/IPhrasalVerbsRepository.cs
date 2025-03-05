using PhrasalVerbs.Application.Models;

namespace PhrasalVerbs.Application.Repositories;

public interface IPhrasalVerbsRepository
{
    Task<PhrasalVerb?> CreateAsync(PhrasalVerb phrasalVerb, CancellationToken token = default);

    Task<PhrasalVerb?> GetByIdAsync(Guid id, CancellationToken token = default);

    Task<PhrasalVerb?> GetBySlugAsync(string slug, CancellationToken token = default);

    Task<IEnumerable<PhrasalVerb>> GetAllAsync(GetAllPhersalVerbsOptions options, CancellationToken token = default);

    Task<bool> UpdateAsync(PhrasalVerb phrasalVerb, CancellationToken token = default);

    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);

    Task<bool> ExistByIdAsync(Guid id, CancellationToken token = default);

    Task<int> GetCountAsync(string? Verb, string? Particle, CancellationToken token = default);
}
