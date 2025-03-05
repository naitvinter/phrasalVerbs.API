using Microsoft.Data.SqlClient;

namespace PhrasalVerbs.Application.Models;

public class GetAllPhersalVerbsOptions
{
    public string? Verb { get; set; }
    public string? Particle { get; set; }

    public string? SortField { get; set; }
    public SortOrder? SortOrder { get; set; }

    public int Page { get; set; }
    public int PageSize { get; set; }
}