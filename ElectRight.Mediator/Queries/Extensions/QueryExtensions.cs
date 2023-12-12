namespace ElectRight.Mediator.Queries.Extensions;

using ElectRight.Mediator.Queries.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

internal static class QueryExtensions
{
    public static IServiceCollection AddQueries(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddSingleton<IQueryBus, InMemoryQueryBus>();
        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}