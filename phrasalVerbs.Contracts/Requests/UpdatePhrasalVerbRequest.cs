namespace PhrasalVerbs.Contracts.Requests;

public class UpdatePhrasalVerbRequest
{
    public required string Verb { get; init; }
    public required IEnumerable<UpdateTranslationRequest> Translations { get; init; } = Enumerable.Empty<UpdateTranslationRequest>();
}
