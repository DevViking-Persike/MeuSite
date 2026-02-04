namespace MeuSite.Shared.Models;

public record ResumeModel
{
    public string FullName { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string AboutMe { get; init; } = string.Empty;
    public string ProfileImageUrl { get; init; } = string.Empty;
    public ContactInfo Contact { get; init; } = new();
    public IReadOnlyList<EducationEntry> Education { get; init; } = [];
    public IReadOnlyList<ExperienceEntry> Experiences { get; init; } = [];
    public IReadOnlyList<SkillEntry> Skills { get; init; } = [];
}
