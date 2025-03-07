using PhrasalVerbs.API.Auth;
using PhrasalVerbs.API.Mapping;
using PhrasalVerbs.Application.Services;
using PhrasalVerbs.Contracts.Requests;

namespace PhrasalVerbs.API.Endpoints;

public static class UpdatePhrasalVerbEndpoint
{
    public const string Name = "UpdatePhrasalVerb";

    public static IEndpointRouteBuilder MapUpdatePhrasalVerb(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiEndpoints.PhrasalVerbs.Update, UpdatePhrasalVerb).
            WithName(Name).RequireAuthorization(AuthConstants.AdminUserPolicyName);
        return app;
    }

    public static async Task<IResult> UpdatePhrasalVerb(Guid id, UpdatePhrasalVerbRequest request, IPhrasalVerbsService _service, CancellationToken token)
    {
        var verb = request.MapToPhrasalVerb(id);

        var updated = await _service.UpdateAsync(verb, token);
        return updated is not null ? TypedResults.Ok(verb.MapToPhrasalVerbResponse()) : TypedResults.NotFound();
    }
}
