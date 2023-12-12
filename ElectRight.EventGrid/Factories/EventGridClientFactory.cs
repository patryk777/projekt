using Azure;
using Azure.Messaging.EventGrid;
using ElectRight.EventGrid.Factories.Interfaces;
using ElectRight.EventGrid.Models.Options;
using Microsoft.Extensions.Options;

namespace ElectRight.EventGrid.Factories;
public class EventGridClientFactory : IEventGridClientFactory
{
    private readonly EventGridOptions _eventGridOptions;

    public EventGridClientFactory(IOptions<EventGridOptions> eventGridOptions)
    {
        _eventGridOptions = eventGridOptions.Value;
    }

    public EventGridPublisherClient CreatePublisher()
    {
        return new EventGridPublisherClient(
            _eventGridOptions.TopicEndpoint,
            new AzureKeyCredential(_eventGridOptions.AccessKey));
    }
}