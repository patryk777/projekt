namespace ElectRight.Core.Options;
public class CorsOptions : IOptions
{
    public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
}
