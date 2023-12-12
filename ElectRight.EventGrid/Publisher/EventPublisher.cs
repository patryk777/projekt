using Azure.Messaging.EventGrid;
using ElectRight.EventGrid.Publisher.Interfaces;
using ElectRight.EventGrid.Models;
using ElectRight.EventGrid.Factories.Interfaces;

namespace ElectRight.EventGrid.Publisher;

public class EventPublisher : IEventPublisher
{
    private const string EventSubject = "ElectRight.Event";
    private const string DataVersion = "1.0";

    private readonly IEventGridClientFactory _eventGridClientFactory;

    public EventPublisher(IEventGridClientFactory eventGridClientFactory)
    {
        _eventGridClientFactory = eventGridClientFactory;
    }

    public async Task Publish(AbstractEvent @event)
    {
        var client = _eventGridClientFactory.CreatePublisher();

        var response = await client.SendEventAsync(new EventGridEvent(
            EventSubject, 
            @event.EventType,
            DataVersion, 
            @event));

        if (response.IsError)
        {
            throw new InvalidOperationException();
        }
    }
}
