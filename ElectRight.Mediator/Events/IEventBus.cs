using ElectRight.EventGrid.Models;

namespace ElectRight.Mediator.Events;
public interface IEventBus
{
    Task Send<TEvent>(TEvent @event) where TEvent : AbstractEvent;
}
