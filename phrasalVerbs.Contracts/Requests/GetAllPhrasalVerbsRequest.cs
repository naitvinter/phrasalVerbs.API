namespace PhrasalVerbs.Contracts.Requests;

public class GetAllPhrasalVerbsRequest : PagedRequest
{
    public string? Verb { get; init; }
    public string? Particle { get; init; }
    public string? SortBy { get; init; }

}
