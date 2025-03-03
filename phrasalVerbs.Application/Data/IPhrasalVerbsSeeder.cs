using PhrasalVerbs.Application.Models;

namespace PhrasalVerbs.Application.Data;

public interface IPhrasalVerbsSeeder
{
    public PhrasalVerb[] GetPharsalVerbs();
    public Translation[] GetTranslations();
}
