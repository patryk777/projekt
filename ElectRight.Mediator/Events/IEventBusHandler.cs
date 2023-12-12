using ElectRight.EventGrid.Models;

namespace ElectRight.Mediator.Events;

public interface IEventHandler<in TEvent> where TEvent : AbstractEvent
{
    Task Handle(TEvent @event);
}