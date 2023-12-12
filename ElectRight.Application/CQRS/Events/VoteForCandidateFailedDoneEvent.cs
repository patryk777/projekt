using ElectRight.EventGrid.Models;

namespace ElectRightApplication.CQRS.Events;

public record VoteForCandidateFailedDoneEvent(string EventType, DateTimeOffset CreatedAt) : AbstractEvent(EventType, CreatedAt)
{
}