using ElectRight.EventGrid.Models;

namespace ElectRightApplication.CQRS.Events;

public record RegisterCandidateOperationDoneEvent(string EventType, DateTimeOffset CreatedAt) : AbstractEvent(EventType, CreatedAt)
{
}