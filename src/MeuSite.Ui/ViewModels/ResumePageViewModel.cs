using MeuSite.Shared.Contracts;
using MeuSite.Shared.Models;

namespace MeuSite.Ui.ViewModels;

public class ResumePageViewModel
{
    private readonly IResumeDataProvider _dataProvider;

    public ResumePageViewModel(IResumeDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public ResumeModel? Resume { get; private set; }
    public bool IsLoading { get; private set; } = true;
    public string? ErrorMessage { get; private set; }

    // Formatted properties for the View
    public string DisplayName => Resume?.FullName ?? string.Empty;
    public string DisplayTitle => Resume?.Title ?? string.Empty;
    public string AboutText => Resume?.AboutMe ?? string.Empty;
    public string ProfileImage => Resume?.ProfileImageUrl ?? "images/profile-placeholder.svg";
    public ContactInfo Contact => Resume?.Contact ?? new();
    public IReadOnlyList<EducationEntry> Education => Resume?.Education ?? [];
    public IReadOnlyList<ExperienceEntry> Experiences => Resume?.Experiences ?? [];
    public IReadOnlyList<SkillEntry> Skills => Resume?.Skills ?? [];

    public async Task LoadAsync()
    {
        try
        {
            IsLoading = true;
            ErrorMessage = null;
            Resume = await _dataProvider.GetResumeAsync();
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Erro ao carregar dados: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }
}
