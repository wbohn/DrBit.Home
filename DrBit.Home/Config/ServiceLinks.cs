namespace DrBit.Home.Config;

public record ServiceLinks
{
    public const string OptionName = "ServiceLinks";
    public const string FileName = "links.json";
    public ICollection<Link> Links { get; set; } = [];
}
