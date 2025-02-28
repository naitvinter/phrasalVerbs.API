namespace PhrasalVerbs.Contracts.Responses;

public class TranslationResponse
{
    public required Guid Id { get; init; }

    public required string Language { get; init; }
    public required string Verb { get; init; }
}
