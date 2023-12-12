using ElectRight.Core.Options;
using Microsoft.Extensions.DependencyInjection;

namespace ElectRight.Core.Extensions;
public static class CorsExtensions
{
    public static IServiceCollection AddCorsWithPolicy(this IServiceCollection services, string policyName, CorsOptions corsOptions, params string[] allowedMethods)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                name: policyName,
                builder =>
                {
                    builder
                            .WithMethods(allowedMethods)
                            .WithOrigins(corsOptions.AllowedOrigins)
                            .AllowAnyHeader()
                            .AllowCredentials();
                });
        });

        return services;
    }
}
