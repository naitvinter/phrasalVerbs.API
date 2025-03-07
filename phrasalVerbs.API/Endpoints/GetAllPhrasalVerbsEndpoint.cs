using PhrasalVerbs.API.Mapping;
using PhrasalVerbs.Application.Services;
using PhrasalVerbs.Contracts.Requests;

namespace PhrasalVerbs.API.Endpoints;

public static class GetAllPhrasalVerbsEndpoint
{
    public const string Name = "GetAllPhrasalVerbs";

    public static IEndpointRouteBuilder MapGetAllPhrasalVerbs(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.PhrasalVerbs.GetAll, GetAllPhrasalVerbs)
            .WithName(Name).RequireAuthorization()
            .WithApiVersionSet(ApiVersioning.VersionSet)
            .HasApiVersion(1.0);

        return app;
    }

    private static async Task<IResult> GetAllPhrasalVerbs([AsParameters]GetAllPhrasalVerbsRequest request, IPhrasalVerbsService _service, CancellationToken token)
    {
        var options = request.MapToOptions();

        var verbs = await _service.GetAllAsync(options, token);
        var verbsCount = await _service.GetCountAsync(options.Verb, options.Particle, token);

        return TypedResults.Ok(verbs.MapToPhrasalVerbsResponse(options.Page, options.PageSize, verbsCount));
    }
}
