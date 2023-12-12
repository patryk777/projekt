using Azure.Messaging.EventGrid;
using ElectRight.EventGrid.Models.Options;

namespace ElectRight.EventGrid.Factories.Interfaces;
public interface IEventGridClientFactory
{
    EventGridPublisherClient CreatePublisher();
}