using Microsoft.EntityFrameworkCore;
using PhrasalVerbs.Application.Database;
using PhrasalVerbs.Application.Models;
using Microsoft.Data.SqlClient;

namespace PhrasalVerbs.Application.Repositories;

public class PhrasalVerbsRepository : IPhrasalVerbsRepository
{
    private PhrasalVerbsContext _context;

    public PhrasalVerbsRepository(PhrasalVerbsContext context)
    {
        _context = context;
    }

    public async Task<PhrasalVerb?> CreateAsync(PhrasalVerb phrasalVerb, CancellationToken token = default)
    {
        var newVerb = _context.PhrasalVerbs.Add(phrasalVerb);
        await _context.SaveChangesAsync(token);

        return newVerb?.Entity;
    }

    public async Task<PhrasalVerb?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _context.PhrasalVerbs
            .AsNoTracking()
            .Include(pv => pv.Translations)
            .SingleOrDefaultAsync(pv => pv.Id == id, token);
    }

    public async Task<PhrasalVerb?> GetBySlugAsync(string slug, CancellationToken token = default)
    {
        return await _context.PhrasalVerbs
            .AsNoTracking()
            .Include(pv => pv.Translations)
            .FirstOrDefaultAsync(pv => pv.Verb.Replace(" ", "-").ToLower() == slug, token);
    }

    public async Task<IEnumerable<PhrasalVerb>> GetAllAsync(GetAllPhersalVerbsOptions options, CancellationToken token = default)
    {
        var query = _context.PhrasalVerbs
            .AsNoTracking()
            .Include(pv => pv.Translations)
            .Skip((options.Page - 1) * options.PageSize)
            .Take(options.PageSize)
            .Where(pv => (options.Verb == null || (options.Verb != null && pv.Verb.Contains(options.Verb))))
            .Where(pv => (options.Particle == null || (options.Particle != null && pv.Verb.Contains(options.Particle))));

        if(options.SortField is not null)
        {
            switch (options.SortField.ToLower())
            {
                case "verb":
                    query = options.SortOrder == SortOrder.Ascending || options.SortOrder == SortOrder.Unspecified
                        ? query.OrderBy(pv => pv.Verb)
                        : query.OrderByDescending(pv => pv.Verb);
                break;

            default:
                    break;
            }
        }

        return await query.ToListAsync(token);
    }

    public async Task<bool> UpdateAsync(PhrasalVerb phrasalVerb, CancellationToken token = default)
    {
        var verb = await _context.PhrasalVerbs
            .SingleOrDefaultAsync(pv => pv.Id == phrasalVerb.Id, token);

        var translations = await _context.Translations
            .Where(t => t.PhrasalVerbId == phrasalVerb.Id)
            .ToListAsync(token);

        verb.Verb = phrasalVerb.Verb;

        for (int i = 0; i < translations.Count; i++)
            _context.Translations.Remove(translations[i]);

        for (int i = 0; i < phrasalVerb.Translations.Count; i++)
        {
            _context.Translations.Add(new Translation
            {
                PhrasalVerbId = verb.Id,
                Language = phrasalVerb.Translations[i].Language,
                Verb = phrasalVerb.Translations[i].Verb,
            });
        }

        return await _context.SaveChangesAsync(token) > 0;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        var verb = await _context.PhrasalVerbs
            .Include(pv => pv.Translations)
            .SingleOrDefaultAsync(pv => pv.Id == id, token);

        _context.PhrasalVerbs.Remove(verb);

        return await _context.SaveChangesAsync(token) > 0;
    }

    public async Task<bool> ExistByIdAsync(Guid id, CancellationToken token = default)
    { 
        return await _context.PhrasalVerbs.AnyAsync(pv => pv.Id == id, token);
    }

    public async Task<int> GetCountAsync(string? Verb, string? Particle, CancellationToken token = default)
    {
        var query = _context.PhrasalVerbs
            .AsNoTracking()
            .Where(pv => (Verb == null || (Verb != null && pv.Verb.Contains(Verb))))
            .Where(pv => (Particle == null || (Particle != null && pv.Verb.Contains(Particle))));

        return await query.CountAsync(token);
    }
}
