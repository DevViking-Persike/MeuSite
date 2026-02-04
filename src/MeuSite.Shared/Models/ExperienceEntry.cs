namespace MeuSite.Shared.Models;

public record ExperienceEntry
{
    public string Company { get; init; } = string.Empty;
    public string Role { get; init; } = string.Empty;
    public string Period { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}
