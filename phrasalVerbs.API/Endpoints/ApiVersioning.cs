using Asp.Versioning.Builder;
using Asp.Versioning.Conventions;

namespace PhrasalVerbs.API.Endpoints;

public static class ApiVersioning
{
    public static ApiVersionSet VersionSet { get; private set; }

    public static IEndpointRouteBuilder CreateApiVersionSet(this IEndpointRouteBuilder app)
    {
        VersionSet = app.NewApiVersionSet().
            HasApiVersion(1.0)
            .Build();

        return app;
    }
}
