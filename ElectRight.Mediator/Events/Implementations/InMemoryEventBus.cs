namespace ElectRight.Mediator.Events.Implementations;

using ElectRight.EventGrid.Models;
using Microsoft.Extensions.DependencyInjection;

public class InMemoryEventBus : IEventBus
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryEventBus(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public Task Send<TEvent>(TEvent? @event) where TEvent : AbstractEvent
    {
        if (@event is null)
        {
            throw new ArgumentNullException(nameof(@event));
        }

        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<IEventHandler<TEvent>>();

        return handler.Handle(@event);
    }
}
