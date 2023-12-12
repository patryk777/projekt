using System.Text.Json;
using Azure.Messaging.EventGrid;
using Azure.Messaging.EventGrid.SystemEvents;
using ElectRight.EventGrid.Models;
using ElectRight.Mediator.Events;
using ElectRightApplication.CQRS.Events;
using Microsoft.AspNetCore.Mvc;

namespace ElectRight.Api.Controllers;

public class WebhookControllerBase : ControllerBase
{
    protected readonly IEventBus _eventBus;

    private const string SubscriptionValidationEvent = "Microsoft.EventGrid.SubscriptionValidationEvent";

    private readonly Dictionary<string, Type> EventTypesDictionary = new()
    {
        { nameof(RegisterCandidateOperationDoneEvent), typeof(RegisterCandidateOperationDoneEvent) }
    };

    protected WebhookControllerBase(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    protected Task ExecuteEvents(EventGridEvent[] events)
    {
        var eventTasks = events.Where(x => x.EventType != SubscriptionValidationEvent)
            .Select(eventGridEvent =>
            {
                var @event = Deserialize(eventGridEvent);
                return SendToEventBus(@event);
            });

        return Task.WhenAll(eventTasks);
    }

    protected AbstractEvent Deserialize(EventGridEvent eventGridEvent)
    {
        if (!EventTypesDictionary.ContainsKey(eventGridEvent.EventType))
        {
            throw new KeyNotFoundException(new("There is no EventType defined in webhook dictionary"));
        }

        var eventStream = eventGridEvent.Data.ToStream();

        Type eventType = EventTypesDictionary[eventGridEvent.EventType];
        var deserializedEvent = JsonSerializer.Deserialize(eventStream, eventType);
        if (deserializedEvent is null)
        {
            throw new InvalidOperationException(new("Cannot deserialize event"));
        }

        if (deserializedEvent is not AbstractEvent)
        {
            throw new InvalidOperationException(new("Cannot handle event, because is not AbstractEvent"));
        }

        return (AbstractEvent)deserializedEvent;

    }

    private Task SendToEventBus(AbstractEvent @event)
    {
        switch (@event)
        {
            case RegisterCandidateOperationDoneEvent registerCandidateOperationDoneEvent:
                return _eventBus.Send(registerCandidateOperationDoneEvent);
            case RegisterVoterOperationDoneEventOperationDoneEvent registerVoteOperationDoneEvent:
                return _eventBus.Send(registerVoteOperationDoneEvent);
            case VoteForCandidateSuccesfulDoneEvent registerCandidateOperationDoneEvent:
                return _eventBus.Send(registerCandidateOperationDoneEvent);
            case VoteForCandidateFailedDoneEvent registerCandidateOperationDoneEvent:
                return _eventBus.Send(registerCandidateOperationDoneEvent);
            default:
                throw new InvalidOperationException("Cannot send unknown event to event bus");
        }
    }

    protected bool TryConvertSubscriptionEvent(EventGridEvent[] eventGridEvents, out SubscriptionValidationEventData subscriptionData)
    {
        if (eventGridEvents.FirstOrDefault(x => x.EventType == SubscriptionValidationEvent) is var subscriptionEvent
            && subscriptionEvent is not null
            && subscriptionEvent.TryGetSystemEventData(out object data)
            && data is SubscriptionValidationEventData validationData)
        {
            subscriptionData = validationData;
            return true;
        }

        subscriptionData = null!;
        return false;
    }
}