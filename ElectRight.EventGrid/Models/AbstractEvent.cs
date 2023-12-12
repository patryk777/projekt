namespace ElectRight.EventGrid.Models;

public abstract record AbstractEvent(string EventType, DateTimeOffset CreatedAt);
