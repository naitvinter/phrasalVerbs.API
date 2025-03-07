using PhrasalVerbs.API.Auth;
using PhrasalVerbs.Application.Services;

namespace PhrasalVerbs.API.Endpoints;

public static class DeletePhrasalVerbEndpoint
{
    public const string Name = "DeletePhrasalVerb";

    public static IEndpointRouteBuilder MapDeletePhrasalVerb(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiEndpoints.PhrasalVerbs.Delete, DeletePhrasalVerb).
            WithName(Name).RequireAuthorization(AuthConstants.AdminUserPolicyName);
        return app;
    }

    private static async Task<IResult> DeletePhrasalVerb(Guid id, IPhrasalVerbsService _service, CancellationToken token)
    {
        var deleted = await _service.DeleteByIdAsync(id, token);
        return deleted ? TypedResults.Ok() : TypedResults.NotFound();
    }
}
