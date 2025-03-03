using System.Text.Json.Serialization;

namespace PhrasalVerbs.Application.Models;

public class Translation
{
    public Guid Id { get; init; }

    [JsonIgnore] 
    public PhrasalVerb PhrasalVerb { get; init; }

    [JsonIgnore]
    public Guid PhrasalVerbId { get; init; }

    public string Language { get; set; }
    public string Verb { get; set; }
}
