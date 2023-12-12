using ElectRight.EventGrid.Factories;
using ElectRight.EventGrid.Factories.Interfaces;
using ElectRight.EventGrid.Models.Options;
using ElectRight.EventGrid.Publisher;
using ElectRight.EventGrid.Publisher.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectRight.EventGrid.Extensions;

public static class EventGridStartupExtensions
{
    public static WebApplicationBuilder AddEventGrid(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IEventGridClientFactory, EventGridClientFactory>();
        builder.Services.AddScoped<IEventPublisher, EventPublisher>();
        builder.Services.Configure<EventGridOptions>(builder.Configuration.GetSection(nameof(EventGridOptions)));

        return builder;
    }
}
