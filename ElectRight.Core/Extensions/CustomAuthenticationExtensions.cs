using ElectRight.Core.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

namespace ElectRight.Core.Extensions;
public static class CustomAuthenticationExtensions
{
    public static IServiceCollection AddCustomAuthentication(
        this IServiceCollection services,
        JwtOptions jwtOptions,
        string authSchemaName = "KontrolkiToken")
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = authSchemaName;
            x.DefaultChallengeScheme = authSchemaName;
            x.DefaultScheme = authSchemaName;
        }).AddJwtBearer(authSchemaName, x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidIssuer = jwtOptions.ValidIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtOptions.TokenSecretKey))
            };

            x.Events = new JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    if (!(context.SecurityToken is JwtSecurityToken jwtToken))
                    {
                        context.Fail("Invalid SecurityToken context");
                        return Task.CompletedTask;
                    }

                    var audienceJsonArray = jwtToken?.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Aud)?.Value;
                    if (string.IsNullOrWhiteSpace(audienceJsonArray))
                    {
                        context.Fail("Token audience is empty");
                        return Task.CompletedTask;
                    }

                    var audienceArray = JsonSerializer.Deserialize<string[]>(audienceJsonArray);
                    if (audienceArray != null && audienceArray.Any(a => a == jwtOptions.ValidAudience))
                    {
                        context.Success();
                    }
                    else
                    {
                        context.Fail("Invalid audience");
                    }

                    return Task.CompletedTask;
                }
            };
        });

        return services;
    }
}
