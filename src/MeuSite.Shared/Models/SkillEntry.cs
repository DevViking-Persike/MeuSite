namespace MeuSite.Shared.Models;

public record SkillEntry
{
    public string Name { get; init; } = string.Empty;
    public int Percentage { get; init; }
}
