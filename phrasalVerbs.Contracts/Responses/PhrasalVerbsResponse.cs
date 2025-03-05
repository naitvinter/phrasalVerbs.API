namespace PhrasalVerbs.Contracts.Responses;

public class PhrasalVerbsResponse : PagedResponse<PhrasalVerbResponse>
{
    public required IEnumerable<PhrasalVerbResponse> Items { get; init; } = Enumerable.Empty<PhrasalVerbResponse>();
}
