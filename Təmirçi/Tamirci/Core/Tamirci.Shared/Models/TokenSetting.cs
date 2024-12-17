namespace Tamirci.Shared.Models;

public class TokenSetting
{
    public string Audience { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Secret { get; set; } = null!;
    public int TokenValidityInMunitues { get; set; }
}
