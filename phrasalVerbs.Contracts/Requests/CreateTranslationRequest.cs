namespace PhrasalVerbs.Contracts.Requests;

public class CreateTranslationRequest
{
    public required string Language { get; init; }
    public required string Verb { get; init; }
}
