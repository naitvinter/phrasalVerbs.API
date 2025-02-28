﻿using Microsoft.Extensions.DependencyInjection;
using PhrasalVerbs.Application.Repositories;

namespace PhrasalVerbs.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IPhrasalVerbsRepository, PhrasalVerbsRepository>();
        return services;
    }
}
