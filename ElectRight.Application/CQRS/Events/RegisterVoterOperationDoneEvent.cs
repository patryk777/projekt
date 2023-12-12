﻿using ElectRight.EventGrid.Models;

namespace ElectRightApplication.CQRS.Events;

public record RegisterVoterOperationDoneEvent(string EventType, DateTimeOffset CreatedAt) : AbstractEvent(EventType, CreatedAt)
{
}