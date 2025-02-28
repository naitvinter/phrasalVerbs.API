namespace PhrasalVerbs.Contracts.Requests;

public class UpdateTranslationRequest
{
    public required string Language { get; init; }
    public required string Verb { get; init; }
}
