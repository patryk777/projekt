namespace ElectRight.Core.Options;
public class JwtOptions
{
    public JwtOptions(string validIssuer, string validAudience, string tokenSecretKey)
    {
        ValidIssuer = validIssuer;
        ValidAudience = validAudience;
        TokenSecretKey = tokenSecretKey;
    }

    public string ValidIssuer { get; set; }

    public string ValidAudience { get; set; }

    public string TokenSecretKey { get; set; }
}
