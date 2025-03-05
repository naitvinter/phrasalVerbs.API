namespace PhrasalVerbs.Contracts.Requests;

public class GetAllPhrasalVerbsRequest : PagedRequest
{
    public required string? Verb { get; init; }
    public required string? Particle { get; init; }
    public required string? SortBy { get; init; }

}
