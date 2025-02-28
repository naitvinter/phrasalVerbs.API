namespace PhrasalVerbs.Application.Models;

public class Translation
{
    public required Guid Id { get; init; }

    public required string Language { get; set; }
    public required string Verb { get; set; }
}
