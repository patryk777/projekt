namespace ElectRight.Mediator.Commands.Extensions;

using ElectRight.Mediator.Commands;
using ElectRight.Mediator.Commands.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

internal static class CommandExtensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddSingleton<ICommandBus, InMemoryCommandBus>();

        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}