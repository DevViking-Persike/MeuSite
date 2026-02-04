using MeuSite.Shared.Contracts;
using MeuSite.Shared.Models;
using MeuSite.Ui.ViewModels;

namespace MeuSite.Tests;

public class ViewModelTests
{
    private class FakeDataProvider : IResumeDataProvider
    {
        public Task<ResumeModel> GetResumeAsync() => Task.FromResult(new ResumeModel
        {
            FullName = "Test User",
            Title = "Test Title",
            AboutMe = "About test",
            Contact = new ContactInfo { Phone = "123", Email = "test@test.com" },
            Education = new List<EducationEntry>
            {
                new() { Period = "2020", Institution = "Uni", Degree = "CS" }
            },
            Experiences = new List<ExperienceEntry>
            {
                new() { Company = "Corp", Role = "Dev", Period = "2021", Description = "Worked" }
            },
            Skills = new List<SkillEntry>
            {
                new() { Name = "C#", Percentage = 90 }
            }
        });
    }

    private class FailingDataProvider : IResumeDataProvider
    {
        public Task<ResumeModel> GetResumeAsync() => throw new InvalidOperationException("Connection failed");
    }

    [Fact]
    public async Task ResumePageViewModel_LoadAsync_ShouldPopulateResume()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        await vm.LoadAsync();

        Assert.False(vm.IsLoading);
        Assert.Null(vm.ErrorMessage);
        Assert.Equal("Test User", vm.DisplayName);
        Assert.Equal("Test Title", vm.DisplayTitle);
        Assert.Single(vm.Skills);
    }

    [Fact]
    public async Task ResumePageViewModel_LoadAsync_OnError_ShouldSetErrorMessage()
    {
        var vm = new ResumePageViewModel(new FailingDataProvider());

        await vm.LoadAsync();

        Assert.False(vm.IsLoading);
        Assert.NotNull(vm.ErrorMessage);
        Assert.Contains("Connection failed", vm.ErrorMessage);
    }

    [Fact]
    public void ResumePageViewModel_BeforeLoad_ShouldBeLoading()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        Assert.True(vm.IsLoading);
        Assert.Equal(string.Empty, vm.DisplayName);
    }

    [Fact]
    public void SkillsViewModel_GetStrokeDashoffset_ShouldCalculateCorrectly()
    {
        var skills = new List<SkillEntry> { new() { Name = "C#", Percentage = 80 } };
        var vm = new SkillsViewModel(skills);

        var circumference = vm.GetCircumference();
        var offset = vm.GetStrokeDashoffset(80);
        var expected = circumference - (80 / 100.0 * circumference);

        Assert.Equal(expected, offset, precision: 2);
    }
}
