using ElectRight.EventGrid.Models;

namespace ElectRight.EventGrid.Publisher.Interfaces;
public interface IEventPublisher
{
    Task Publish(AbstractEvent @event);
}
