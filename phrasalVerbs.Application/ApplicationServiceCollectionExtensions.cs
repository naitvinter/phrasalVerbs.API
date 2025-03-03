using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PhrasalVerbs.Application.Data;
using PhrasalVerbs.Application.Database;
using PhrasalVerbs.Application.Repositories;
using PhrasalVerbs.Application.Services;

namespace PhrasalVerbs.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPhrasalVerbsRepository, PhrasalVerbsRepository>();
        services.AddScoped<IPhrasalVerbsService, PhrasalVerbService>();

        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Scoped);

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddTransient<IPhrasalVerbsSeeder, PhrasalVerbsSeeder>();

        services.AddSqlServer<PhrasalVerbsContext>(connectionString);

        return services;
    }
}
