using PhrasalVerbs.Application.Models;

namespace PhrasalVerbs.Application.Repositories;

public interface IPhrasalVerbsRepository
{
    Task<PhrasalVerb> CreateAsync(PhrasalVerb phrasalVerb);

    Task<PhrasalVerb> GetByIdAsync(Guid id);

    Task<IEnumerable<PhrasalVerb>> GetAllAsync();

    Task<bool> UpdateAsync(PhrasalVerb phrasalVerb);

    Task<bool> DeleteByIdAsync(Guid id);
}
