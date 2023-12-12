using Azure.Messaging.EventGrid;
using Azure.Messaging.EventGrid.SystemEvents;
using ElectRight.Mediator.Events;
using ElectRightApplication.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ElectRight.Api.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[ApiController]
[Route("[controller]")]
public class WebhookController : WebhookControllerBase
{
    public WebhookController(IEventBus eventBus) : base(eventBus)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Webhook([FromBody] EventGridEvent[] request)
    {
        if (TryConvertSubscriptionEvent(request, out SubscriptionValidationEventData subscriptionEvent))
        {
            return Ok(new WebhookValidationDto(subscriptionEvent.ValidationCode));
        }

        await ExecuteEvents(request);

        return Ok();
    }
}
