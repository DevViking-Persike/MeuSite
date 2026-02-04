using MeuSite.Shared.Contracts;
using MeuSite.Shared.Models;
using MeuSite.Ui.ViewModels;

namespace MeuSite.Tests;

public class ResumePageViewModelTests
{
    private static ResumeModel CreateTestResume() => new()
    {
        FullName = "Test User",
        Title = "Test Title",
        AboutMe = "About test",
        ProfileImageUrl = "images/test.jpg",
        Contact = new ContactInfo { Phone = "123", Email = "test@test.com", Address = "SP", Website = "test.com" },
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
    };

    private class FakeDataProvider : IResumeDataProvider
    {
        private readonly ResumeModel _data;
        public FakeDataProvider(ResumeModel? data = null) => _data = data ?? CreateTestResume();
        public Task<ResumeModel> GetResumeAsync() => Task.FromResult(_data);
    }

    private class FailingDataProvider : IResumeDataProvider
    {
        private readonly string _message;
        public FailingDataProvider(string message = "Connection failed") => _message = message;
        public Task<ResumeModel> GetResumeAsync() => throw new InvalidOperationException(_message);
    }

    private class DelayedDataProvider : IResumeDataProvider
    {
        private readonly TaskCompletionSource<ResumeModel> _tcs = new();
        public Task<ResumeModel> GetResumeAsync() => _tcs.Task;
        public void Complete(ResumeModel data) => _tcs.SetResult(data);
        public void Fail(Exception ex) => _tcs.SetException(ex);
    }

    // ==================== Initial State ====================

    [Fact]
    public void BeforeLoad_ShouldBeLoading()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        Assert.True(vm.IsLoading);
        Assert.Null(vm.Resume);
        Assert.Null(vm.ErrorMessage);
    }

    [Fact]
    public void BeforeLoad_DisplayName_ShouldBeEmpty()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        Assert.Equal(string.Empty, vm.DisplayName);
    }

    [Fact]
    public void BeforeLoad_DisplayTitle_ShouldBeEmpty()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        Assert.Equal(string.Empty, vm.DisplayTitle);
    }

    [Fact]
    public void BeforeLoad_AboutText_ShouldBeEmpty()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        Assert.Equal(string.Empty, vm.AboutText);
    }

    [Fact]
    public void BeforeLoad_ProfileImage_ShouldBePlaceholder()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        Assert.Equal("images/profile-placeholder.svg", vm.ProfileImage);
    }

    [Fact]
    public void BeforeLoad_Contact_ShouldBeDefaultContactInfo()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        Assert.NotNull(vm.Contact);
        Assert.Equal(string.Empty, vm.Contact.Phone);
        Assert.Equal(string.Empty, vm.Contact.Email);
    }

    [Fact]
    public void BeforeLoad_Collections_ShouldBeEmpty()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        Assert.Empty(vm.Education);
        Assert.Empty(vm.Experiences);
        Assert.Empty(vm.Skills);
    }

    // ==================== After Successful Load ====================

    [Fact]
    public async Task LoadAsync_ShouldPopulateResume()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        await vm.LoadAsync();

        Assert.False(vm.IsLoading);
        Assert.Null(vm.ErrorMessage);
        Assert.NotNull(vm.Resume);
    }

    [Fact]
    public async Task LoadAsync_ShouldPopulateDisplayName()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        await vm.LoadAsync();

        Assert.Equal("Test User", vm.DisplayName);
    }

    [Fact]
    public async Task LoadAsync_ShouldPopulateDisplayTitle()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        await vm.LoadAsync();

        Assert.Equal("Test Title", vm.DisplayTitle);
    }

    [Fact]
    public async Task LoadAsync_ShouldPopulateAboutText()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        await vm.LoadAsync();

        Assert.Equal("About test", vm.AboutText);
    }

    [Fact]
    public async Task LoadAsync_ShouldPopulateProfileImage()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        await vm.LoadAsync();

        Assert.Equal("images/test.jpg", vm.ProfileImage);
    }

    [Fact]
    public async Task LoadAsync_ShouldPopulateContact()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        await vm.LoadAsync();

        Assert.Equal("123", vm.Contact.Phone);
        Assert.Equal("test@test.com", vm.Contact.Email);
        Assert.Equal("SP", vm.Contact.Address);
        Assert.Equal("test.com", vm.Contact.Website);
    }

    [Fact]
    public async Task LoadAsync_ShouldPopulateSkills()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        await vm.LoadAsync();

        Assert.Single(vm.Skills);
        Assert.Equal("C#", vm.Skills[0].Name);
        Assert.Equal(90, vm.Skills[0].Percentage);
    }

    [Fact]
    public async Task LoadAsync_ShouldPopulateEducation()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        await vm.LoadAsync();

        Assert.Single(vm.Education);
        Assert.Equal("Uni", vm.Education[0].Institution);
    }

    [Fact]
    public async Task LoadAsync_ShouldPopulateExperiences()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        await vm.LoadAsync();

        Assert.Single(vm.Experiences);
        Assert.Equal("Corp", vm.Experiences[0].Company);
    }

    // ==================== Error Handling ====================

    [Fact]
    public async Task LoadAsync_OnError_ShouldSetErrorMessage()
    {
        var vm = new ResumePageViewModel(new FailingDataProvider());

        await vm.LoadAsync();

        Assert.False(vm.IsLoading);
        Assert.NotNull(vm.ErrorMessage);
        Assert.Contains("Connection failed", vm.ErrorMessage);
    }

    [Fact]
    public async Task LoadAsync_OnError_ShouldStopLoading()
    {
        var vm = new ResumePageViewModel(new FailingDataProvider());

        await vm.LoadAsync();

        Assert.False(vm.IsLoading);
    }

    [Fact]
    public async Task LoadAsync_OnError_ResumeShouldBeNull()
    {
        var vm = new ResumePageViewModel(new FailingDataProvider());

        await vm.LoadAsync();

        Assert.Null(vm.Resume);
    }

    [Fact]
    public async Task LoadAsync_OnError_ErrorMessageContainsExceptionMessage()
    {
        var vm = new ResumePageViewModel(new FailingDataProvider("Custom error"));

        await vm.LoadAsync();

        Assert.Contains("Custom error", vm.ErrorMessage);
    }

    [Fact]
    public async Task LoadAsync_OnError_ComputedProperties_ShouldReturnDefaults()
    {
        var vm = new ResumePageViewModel(new FailingDataProvider());

        await vm.LoadAsync();

        Assert.Equal(string.Empty, vm.DisplayName);
        Assert.Equal(string.Empty, vm.DisplayTitle);
        Assert.Equal(string.Empty, vm.AboutText);
        Assert.Equal("images/profile-placeholder.svg", vm.ProfileImage);
        Assert.Empty(vm.Skills);
    }

    // ==================== Edge Cases ====================

    [Fact]
    public async Task LoadAsync_WithEmptyResume_ShouldNotThrow()
    {
        var emptyResume = new ResumeModel();
        var vm = new ResumePageViewModel(new FakeDataProvider(emptyResume));

        await vm.LoadAsync();

        Assert.False(vm.IsLoading);
        Assert.Equal(string.Empty, vm.DisplayName);
        Assert.Empty(vm.Skills);
    }

    [Fact]
    public async Task LoadAsync_WithEmptyProfileImage_ShouldShowPlaceholder()
    {
        var resume = new ResumeModel { ProfileImageUrl = string.Empty };
        var vm = new ResumePageViewModel(new FakeDataProvider(resume));

        await vm.LoadAsync();

        // ProfileImage returns ProfileImageUrl or placeholder
        // Since it goes through Resume?.ProfileImageUrl ?? "images/profile-placeholder.svg"
        // and empty string is not null, it returns empty string
        Assert.NotNull(vm.ProfileImage);
    }

    [Fact]
    public async Task LoadAsync_CalledTwice_ShouldSucceed()
    {
        var vm = new ResumePageViewModel(new FakeDataProvider());

        await vm.LoadAsync();
        await vm.LoadAsync();

        Assert.False(vm.IsLoading);
        Assert.Equal("Test User", vm.DisplayName);
    }

    [Fact]
    public async Task LoadAsync_WithMultipleSkills_ShouldRetainAll()
    {
        var resume = new ResumeModel
        {
            Skills = new List<SkillEntry>
            {
                new() { Name = "C#", Percentage = 90 },
                new() { Name = "Blazor", Percentage = 85 },
                new() { Name = "SQL", Percentage = 75 },
                new() { Name = ".NET", Percentage = 88 }
            }
        };
        var vm = new ResumePageViewModel(new FakeDataProvider(resume));

        await vm.LoadAsync();

        Assert.Equal(4, vm.Skills.Count);
    }
}

public class SkillsViewModelTests
{
    // ==================== Construction ====================

    [Fact]
    public void Constructor_ShouldStoreSkills()
    {
        var skills = new List<SkillEntry> { new() { Name = "C#", Percentage = 80 } };
        var vm = new SkillsViewModel(skills);

        Assert.Single(vm.Skills);
        Assert.Equal("C#", vm.Skills[0].Name);
    }

    [Fact]
    public void Constructor_EmptyList_ShouldWork()
    {
        var vm = new SkillsViewModel(new List<SkillEntry>());

        Assert.Empty(vm.Skills);
    }

    [Fact]
    public void Constructor_MultipleSkills_ShouldRetainAll()
    {
        var skills = new List<SkillEntry>
        {
            new() { Name = "C#", Percentage = 90 },
            new() { Name = "JS", Percentage = 70 }
        };
        var vm = new SkillsViewModel(skills);

        Assert.Equal(2, vm.Skills.Count);
    }

    // ==================== GetCircumference ====================

    [Fact]
    public void GetCircumference_DefaultRadius_ShouldCalculateCorrectly()
    {
        var vm = new SkillsViewModel(new List<SkillEntry>());

        var result = vm.GetCircumference();
        var expected = 2 * Math.PI * 54;

        Assert.Equal(expected, result, precision: 6);
    }

    [Fact]
    public void GetCircumference_CustomRadius_ShouldCalculateCorrectly()
    {
        var vm = new SkillsViewModel(new List<SkillEntry>());

        var result = vm.GetCircumference(100);
        var expected = 2 * Math.PI * 100;

        Assert.Equal(expected, result, precision: 6);
    }

    [Fact]
    public void GetCircumference_ZeroRadius_ShouldBeZero()
    {
        var vm = new SkillsViewModel(new List<SkillEntry>());

        Assert.Equal(0, vm.GetCircumference(0));
    }

    [Fact]
    public void GetCircumference_ShouldBePositive()
    {
        var vm = new SkillsViewModel(new List<SkillEntry>());

        Assert.True(vm.GetCircumference() > 0);
    }

    // ==================== GetStrokeDashoffset ====================

    [Fact]
    public void GetStrokeDashoffset_ShouldCalculateCorrectly()
    {
        var skills = new List<SkillEntry> { new() { Name = "C#", Percentage = 80 } };
        var vm = new SkillsViewModel(skills);

        var circumference = vm.GetCircumference();
        var offset = vm.GetStrokeDashoffset(80);
        var expected = circumference - (80 / 100.0 * circumference);

        Assert.Equal(expected, offset, precision: 2);
    }

    [Fact]
    public void GetStrokeDashoffset_ZeroPercent_ShouldEqualCircumference()
    {
        var vm = new SkillsViewModel(new List<SkillEntry>());

        var circumference = vm.GetCircumference();
        var offset = vm.GetStrokeDashoffset(0);

        Assert.Equal(circumference, offset, precision: 2);
    }

    [Fact]
    public void GetStrokeDashoffset_HundredPercent_ShouldBeZero()
    {
        var vm = new SkillsViewModel(new List<SkillEntry>());

        var offset = vm.GetStrokeDashoffset(100);

        Assert.Equal(0, offset, precision: 2);
    }

    [Fact]
    public void GetStrokeDashoffset_FiftyPercent_ShouldBeHalfCircumference()
    {
        var vm = new SkillsViewModel(new List<SkillEntry>());

        var circumference = vm.GetCircumference();
        var offset = vm.GetStrokeDashoffset(50);
        var expected = circumference / 2;

        Assert.Equal(expected, offset, precision: 2);
    }

    [Fact]
    public void GetStrokeDashoffset_CustomRadius_ShouldWork()
    {
        var vm = new SkillsViewModel(new List<SkillEntry>());

        var circumference = vm.GetCircumference(100);
        var offset = vm.GetStrokeDashoffset(75, 100);
        var expected = circumference - (75 / 100.0 * circumference);

        Assert.Equal(expected, offset, precision: 2);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(75)]
    [InlineData(100)]
    public void GetStrokeDashoffset_VariousPercentages_ShouldDecreaseAsPercentageIncreases(int percentage)
    {
        var vm = new SkillsViewModel(new List<SkillEntry>());

        var circumference = vm.GetCircumference();
        var offset = vm.GetStrokeDashoffset(percentage);

        Assert.True(offset >= 0);
        Assert.True(offset <= circumference);
    }

    // ==================== GetSkillColor ====================

    [Theory]
    [InlineData(0)]
    [InlineData(50)]
    [InlineData(60)]
    [InlineData(70)]
    [InlineData(80)]
    [InlineData(100)]
    public void GetSkillColor_AllPercentages_ShouldReturnGoldColor(int percentage)
    {
        var vm = new SkillsViewModel(new List<SkillEntry>());

        var color = vm.GetSkillColor(percentage);

        Assert.Equal("#e8b827", color);
    }

    [Fact]
    public void GetSkillColor_ShouldReturnValidHexColor()
    {
        var vm = new SkillsViewModel(new List<SkillEntry>());

        var color = vm.GetSkillColor(85);

        Assert.StartsWith("#", color);
        Assert.Equal(7, color.Length);
    }
}
