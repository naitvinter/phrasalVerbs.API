using PhrasalVerbs.API.Mapping;
using PhrasalVerbs.Application.Services;

namespace PhrasalVerbs.API.Endpoints;

public static class GetPhrasalVerbEndpoint
{
    public const string Name = "GetPhrasalVerb";

    public static IEndpointRouteBuilder MapGetPhrasalVerb(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.PhrasalVerbs.Get, GetPhrasalVerb)
            .WithName(Name).RequireAuthorization()
            .WithApiVersionSet(ApiVersioning.VersionSet)
            .HasApiVersion(1.0);

        return app;
    }

    private static async Task<IResult> GetPhrasalVerb(string idOrSlug, IPhrasalVerbsService _service, CancellationToken token)
    {
        var verb = Guid.TryParse(idOrSlug, out var id)
            ? await _service.GetByIdAsync(id, token)
            : await _service.GetBySlugAsync(idOrSlug, token);

        return verb is not null ? TypedResults.Ok(verb.MapToPhrasalVerbResponse()) : TypedResults.NotFound();
    }
}
