namespace PhrasalVerbs.Contracts.Responses;

public class PhrasalVerbResponse
{
    public required Guid Id { get; init; }

    public required string Verb { get; init; }
    public required IEnumerable<TranslationResponse> Translations { get; init; } = Enumerable.Empty<TranslationResponse>();
}
