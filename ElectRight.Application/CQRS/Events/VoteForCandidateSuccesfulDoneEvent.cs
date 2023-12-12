using ElectRight.EventGrid.Models;

namespace ElectRightApplication.CQRS.Events;

public record VoteForCandidateSuccesfulDoneEvent(string EventType, DateTimeOffset CreatedAt) : AbstractEvent(EventType, CreatedAt)
{
}