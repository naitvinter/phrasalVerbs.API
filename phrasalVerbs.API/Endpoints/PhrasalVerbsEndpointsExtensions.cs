namespace PhrasalVerbs.API.Endpoints;

public static class PhrasalVerbsEndpointsExtensions
{
    public static IEndpointRouteBuilder MapPhrasalVerbsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGetPhrasalVerb();
        app.MapGetAllPhrasalVerbs();

        app.MapCreatePhrasalVerb();

        app.MapUpdatePhrasalVerb();

        app.MapDeletePhrasalVerb();

        return app;
    }
}
