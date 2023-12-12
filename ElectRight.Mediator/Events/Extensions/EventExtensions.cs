using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ElectRight.Mediator.Events.Implementations;

namespace ElectRight.Mediator.Events.Extensions;

internal static class EventsExtensions
{
    public static IServiceCollection AddEvents(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddSingleton<IEventBus, InMemoryEventBus>();

        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }

}