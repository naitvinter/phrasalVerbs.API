using PhrasalVerbs.API.Auth;
using PhrasalVerbs.API.Mapping;
using PhrasalVerbs.Application.Services;
using PhrasalVerbs.Contracts.Requests;

namespace PhrasalVerbs.API.Endpoints;

public static class CreatePhrasalVerbEndpoint
{
    public const string Name = "CreatePhrasalVerb";

    public static IEndpointRouteBuilder MapCreatePhrasalVerb(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.PhrasalVerbs.Create, CreatePhrasalVerb)
            .WithName(Name).RequireAuthorization(AuthConstants.AdminUserPolicyName)
            .WithApiVersionSet(ApiVersioning.VersionSet)
            .HasApiVersion(1.0);

        return app;
    }
    private static async Task<IResult> CreatePhrasalVerb(CreatePhrasalVerbRequest request, IPhrasalVerbsService _service, CancellationToken token)
    {
        var requestVerb = request.MapToPhrasalVerb();
        var newVerb = await _service.CreateAsync(requestVerb, token);

        if (newVerb is null)
            return TypedResults.Ok();

        return TypedResults.CreatedAtRoute(newVerb.MapToPhrasalVerbResponse(), CreatePhrasalVerbEndpoint.Name, new {idOrSlug = newVerb.Id});
    }
}
