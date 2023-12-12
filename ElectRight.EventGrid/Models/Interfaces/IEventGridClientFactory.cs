using Azure.Messaging.EventGrid;

namespace ElectRight.EventGrid.Models.Interfaces;
public interface IEventGridClientFactory
{
    EventGridPublisherClient Create(string topicEndpoint);
}
