namespace ElectRight.EventGrid.Models.Options;

public class EventGridOptions
{
    public string AccessKey { get; set; } = string.Empty;

    public Uri? TopicEndpoint { get; set; }
}
