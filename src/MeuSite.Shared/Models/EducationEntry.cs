namespace MeuSite.Shared.Models;

public record EducationEntry
{
    public string Period { get; init; } = string.Empty;
    public string Institution { get; init; } = string.Empty;
    public string Degree { get; init; } = string.Empty;
}
