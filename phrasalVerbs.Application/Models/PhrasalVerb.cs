namespace PhrasalVerbs.Application.Models;

public class PhrasalVerb
{
    public Guid Id { get; init; }

    public string Slug => Verb.Replace(" ", "-").ToLower();

    public string Verb { get; set; }

    public List<Translation> Translations { get; set; } = new();
}