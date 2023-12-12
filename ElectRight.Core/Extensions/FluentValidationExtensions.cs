using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElectRight.Core.Extensions;
public static class FluentValidationExtensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        return services.AddFluentValidationAutoValidation(options =>
        {
            options.DisableDataAnnotationsValidation = true;
        });
    }
}
