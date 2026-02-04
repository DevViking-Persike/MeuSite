using MeuSite.Shared.Models;

namespace MeuSite.Ui.ViewModels;

public class SkillsViewModel
{
    public IReadOnlyList<SkillEntry> Skills { get; }

    public SkillsViewModel(IReadOnlyList<SkillEntry> skills)
    {
        Skills = skills;
    }

    public double GetCircumference(double radius = 54) => 2 * Math.PI * radius;

    public double GetStrokeDashoffset(int percentage, double radius = 54)
    {
        var circumference = GetCircumference(radius);
        return circumference - (percentage / 100.0 * circumference);
    }

    public string GetSkillColor(int percentage) => percentage switch
    {
        >= 80 => "#e8b827",
        >= 70 => "#e8b827",
        >= 60 => "#e8b827",
        _ => "#e8b827"
    };
}
