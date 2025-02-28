namespace PhrasalVerbs.Contracts.Responses;

public class PhrasalVerbsResponse
{
    public required IEnumerable<PhrasalVerbResponse> Items { get; init; } = Enumerable.Empty<PhrasalVerbResponse>();
}
