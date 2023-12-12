using ElectRight.EventGrid.Models;

namespace ElectRightApplication.CQRS.Events;

public record RegisterVoterOperationDoneEventOperationDoneEvent(string EventType, DateTimeOffset CreatedAt) : AbstractEvent(EventType, CreatedAt)
{
}