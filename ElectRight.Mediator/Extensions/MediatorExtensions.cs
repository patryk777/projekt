namespace ElectRight.Mediator.Extensions;

using Microsoft.Extensions.DependencyInjection;
using ElectRight.Core.Extensions;
using ElectRight.Mediator.Queries.Extensions;
using ElectRight.Mediator.Commands.Extensions;
using ElectRight.Mediator.Events.Extensions;

public static class MediatorExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services, string appName)
    {
        var assemblies = AssemblyExtensions.GetAssemblies(appName);

        services
            .AddQueries(assemblies)
            .AddCommands(assemblies)
            .AddEvents(assemblies);

        return services;
    }
}