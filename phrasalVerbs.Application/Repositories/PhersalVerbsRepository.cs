using PhrasalVerbs.Application.Models;

namespace PhrasalVerbs.Application.Repositories;

public class PhrasalVerbsRepository : IPhrasalVerbsRepository
{
    private readonly List<PhrasalVerb> _phrasalVerbs = new();

    public Task<PhrasalVerb> CreateAsync(PhrasalVerb phrasalVerb)
    {
        _phrasalVerbs.Add(phrasalVerb);
        return Task.FromResult(phrasalVerb);
    }

    public Task<PhrasalVerb> GetByIdAsync(Guid id)
    {
        var phersalVerb = _phrasalVerbs.SingleOrDefault(pv => pv.Id == id);
        return Task.FromResult(phersalVerb);
    }

    public Task<IEnumerable<PhrasalVerb>> GetAllAsync()
    {
        return Task.FromResult(_phrasalVerbs.AsEnumerable());
    }

    public Task<bool> UpdateAsync(PhrasalVerb phrasalVerb)
    {
        var phersalIndex = _phrasalVerbs.FindIndex(pv => pv.Id == phrasalVerb.Id);

        if (phersalIndex == -1)
        {
            return Task.FromResult(false);
        }

        _phrasalVerbs[phersalIndex] = phrasalVerb;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var removedCount = _phrasalVerbs.RemoveAll(pv => pv.Id == id);
        return Task.FromResult(removedCount > 0);
    }
}
