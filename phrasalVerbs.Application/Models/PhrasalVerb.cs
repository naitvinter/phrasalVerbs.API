namespace PhrasalVerbs.Application.Models;

public class PhrasalVerb
{
    public required Guid Id { get; init; }

    public required string Verb { get; set; }
    public required List<Translation> Translations { get; init; } = new();
}