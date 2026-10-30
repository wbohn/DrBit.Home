namespace DrBit.Home.Config;

public record Link
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty; // schema://host:port/path
    public string Icon { get; set; } = string.Empty; // TV, Movie, etc.
    public string Category { get; set; } = string.Empty; // Media, Admin, etc.
}
