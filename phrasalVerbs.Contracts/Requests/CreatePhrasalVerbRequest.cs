namespace PhrasalVerbs.Contracts.Requests;

public class CreatePhrasalVerbRequest
{
    public required string Verb { get; init; }
    public required IEnumerable<CreateTranslationRequest> Translations { get; init; } = Enumerable.Empty<CreateTranslationRequest>();
}
