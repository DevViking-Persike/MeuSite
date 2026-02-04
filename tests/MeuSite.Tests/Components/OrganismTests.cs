using Bunit;
using Microsoft.Extensions.DependencyInjection;
using MeuSite.Shared.Contracts;
using MeuSite.Shared.Models;
using MeuSite.Ui.Components.Organisms;
using MeuSite.Ui.ViewModels;

namespace MeuSite.Tests.Components;

public class OrganismTests : BunitContext
{
    private readonly ResumePageViewModel _viewModel;

    public OrganismTests()
    {
        var provider = new FakeDataProvider();
        _viewModel = new ResumePageViewModel(provider);
        _viewModel.LoadAsync().GetAwaiter().GetResult();

        Services.AddSingleton(_viewModel);
    }

    // ==================== HeroSection ====================

    [Fact]
    public void HeroSection_ShouldRenderNameAndTitle()
    {
        var cut = Render<HeroSection>();

        var name = cut.Find(".hero-name");
        Assert.Equal("Victor Persike", name.TextContent);

        var title = cut.Find(".hero-title");
        Assert.Equal("Desenvolvedor Full-Stack", title.TextContent);
    }

    [Fact]
    public void HeroSection_ShouldRenderAboutText()
    {
        var cut = Render<HeroSection>();

        var about = cut.Find(".hero-about");
        Assert.Contains("Sobre mim texto", about.TextContent);
    }

    [Fact]
    public void HeroSection_ShouldRenderDownloadButton()
    {
        var cut = Render<HeroSection>();

        var btn = cut.Find(".btn-download");
        Assert.NotNull(btn);
        Assert.Contains("Baixar CV", btn.TextContent);
        Assert.Equal("_content/MeuSite.Ui/docs/curriculo-persike.pdf", btn.GetAttribute("href"));
    }

    [Fact]
    public void HeroSection_ShouldRenderAsSection()
    {
        var cut = Render<HeroSection>();

        var section = cut.Find("section.hero-section");
        Assert.NotNull(section);
    }

    [Fact]
    public void HeroSection_ShouldRenderProfilePhoto()
    {
        var cut = Render<HeroSection>();

        var photo = cut.Find(".profile-photo img");
        Assert.NotNull(photo);
        Assert.Equal("images/profile.jpg", photo.GetAttribute("src"));
    }

    [Fact]
    public void HeroSection_ShouldRenderAboutLabel()
    {
        var cut = Render<HeroSection>();

        var label = cut.Find(".hero-about-label");
        Assert.Equal("Sobre mim", label.TextContent);
    }

    [Fact]
    public void HeroSection_ShouldRenderDecorativeDots()
    {
        var cut = Render<HeroSection>();

        var dots = cut.Find(".decorative-dots");
        Assert.NotNull(dots);
    }

    [Fact]
    public void HeroSection_DownloadButton_ShouldHaveDownloadAttribute()
    {
        var cut = Render<HeroSection>();

        var btn = cut.Find(".btn-download");
        Assert.True(btn.HasAttribute("download"));
    }

    [Fact]
    public void HeroSection_NameRenderedAsH1()
    {
        var cut = Render<HeroSection>();

        var h1 = cut.Find("h1.hero-name");
        Assert.NotNull(h1);
    }

    // ==================== ContactSidebar ====================

    [Fact]
    public void ContactSidebar_ShouldRenderContactInfo()
    {
        var cut = Render<ContactSidebar>();

        var sidebar = cut.Find(".contact-sidebar");
        Assert.NotNull(sidebar);

        var sidebarTitle = cut.Find(".sidebar-title");
        Assert.Equal("Contato", sidebarTitle.TextContent);
    }

    [Fact]
    public void ContactSidebar_ShouldRenderAsAside()
    {
        var cut = Render<ContactSidebar>();

        var aside = cut.Find("aside.contact-sidebar");
        Assert.NotNull(aside);
    }

    [Fact]
    public void ContactSidebar_ShouldRenderFourContactItems()
    {
        var cut = Render<ContactSidebar>();

        var items = cut.FindAll(".contact-item");
        Assert.Equal(4, items.Count);
    }

    [Fact]
    public void ContactSidebar_ShouldRenderPhoneValue()
    {
        var cut = Render<ContactSidebar>();

        var values = cut.FindAll(".contact-value");
        Assert.Contains(values, v => v.TextContent == "(11) 99999-9999");
    }

    [Fact]
    public void ContactSidebar_ShouldRenderEmailValue()
    {
        var cut = Render<ContactSidebar>();

        var values = cut.FindAll(".contact-value");
        Assert.Contains(values, v => v.TextContent == "victor@test.com");
    }

    [Fact]
    public void ContactSidebar_ShouldRenderLabels()
    {
        var cut = Render<ContactSidebar>();

        var labels = cut.FindAll(".contact-label");
        Assert.Equal(4, labels.Count);
    }

    // ==================== SkillsSection ====================

    [Fact]
    public void SkillsSection_ShouldRenderAllSkills()
    {
        var cut = Render<SkillsSection>();

        var section = cut.Find(".skills-section");
        Assert.NotNull(section);

        var header = cut.Find(".section-header");
        Assert.Contains("Skills", header.TextContent);
    }

    [Fact]
    public void SkillsSection_ShouldRenderCorrectNumberOfSkillItems()
    {
        var cut = Render<SkillsSection>();

        var skillItems = cut.FindAll(".skill-item");
        Assert.Equal(2, skillItems.Count);
    }

    [Fact]
    public void SkillsSection_ShouldRenderAsSection()
    {
        var cut = Render<SkillsSection>();

        var section = cut.Find("section.skills-section");
        Assert.NotNull(section);
    }

    [Fact]
    public void SkillsSection_ShouldRenderSkillNames()
    {
        var cut = Render<SkillsSection>();

        var names = cut.FindAll(".skill-name");
        Assert.Contains(names, n => n.TextContent == "C#");
        Assert.Contains(names, n => n.TextContent == "Blazor");
    }

    [Fact]
    public void SkillsSection_ShouldRenderSkillPercentages()
    {
        var cut = Render<SkillsSection>();

        var percentages = cut.FindAll(".percentage");
        Assert.Contains(percentages, p => p.TextContent == "90%");
        Assert.Contains(percentages, p => p.TextContent == "85%");
    }

    // ==================== EducationSection ====================

    [Fact]
    public void EducationSection_ShouldRenderSection()
    {
        var cut = Render<EducationSection>();

        var section = cut.Find("section.education-section");
        Assert.NotNull(section);
    }

    [Fact]
    public void EducationSection_ShouldRenderTitle()
    {
        var cut = Render<EducationSection>();

        var header = cut.Find(".section-header");
        Assert.Contains("Educa", header.TextContent);
    }

    [Fact]
    public void EducationSection_ShouldRenderEducationEntries()
    {
        var cut = Render<EducationSection>();

        var entries = cut.FindAll(".education-entry");
        Assert.Single(entries);
    }

    [Fact]
    public void EducationSection_ShouldRenderInstitution()
    {
        var cut = Render<EducationSection>();

        var institution = cut.Find(".institution");
        Assert.Equal("Faculdade", institution.TextContent);
    }

    [Fact]
    public void EducationSection_ShouldRenderPeriod()
    {
        var cut = Render<EducationSection>();

        var period = cut.Find(".period");
        Assert.Equal("2022 - 2026", period.TextContent);
    }

    [Fact]
    public void EducationSection_ShouldRenderDegree()
    {
        var cut = Render<EducationSection>();

        var degree = cut.Find(".degree");
        Assert.Equal("CC", degree.TextContent);
    }

    [Fact]
    public void EducationSection_ShouldHaveEducationGrid()
    {
        var cut = Render<EducationSection>();

        var grid = cut.Find(".education-grid");
        Assert.NotNull(grid);
    }

    // ==================== ExperienceSection ====================

    [Fact]
    public void ExperienceSection_ShouldRenderSection()
    {
        var cut = Render<ExperienceSection>();

        var section = cut.Find("section.experience-section");
        Assert.NotNull(section);
    }

    [Fact]
    public void ExperienceSection_ShouldRenderTitle()
    {
        var cut = Render<ExperienceSection>();

        var header = cut.Find(".section-header");
        Assert.Contains("Experi", header.TextContent);
    }

    [Fact]
    public void ExperienceSection_ShouldRenderExperienceCards()
    {
        var cut = Render<ExperienceSection>();

        var cards = cut.FindAll(".experience-card");
        Assert.Single(cards);
    }

    [Fact]
    public void ExperienceSection_ShouldRenderCompanyName()
    {
        var cut = Render<ExperienceSection>();

        var company = cut.Find(".company");
        Assert.Equal("Empresa", company.TextContent);
    }

    [Fact]
    public void ExperienceSection_ShouldRenderDescription()
    {
        var cut = Render<ExperienceSection>();

        var desc = cut.Find(".description");
        Assert.Equal("Desc", desc.TextContent);
    }

    [Fact]
    public void ExperienceSection_ShouldHaveExperienceGrid()
    {
        var cut = Render<ExperienceSection>();

        var grid = cut.Find(".experience-grid");
        Assert.NotNull(grid);
    }

    // ==================== Shared Fake Data Provider ====================

    private class FakeDataProvider : IResumeDataProvider
    {
        public Task<ResumeModel> GetResumeAsync() => Task.FromResult(new ResumeModel
        {
            FullName = "Victor Persike",
            Title = "Desenvolvedor Full-Stack",
            AboutMe = "Sobre mim texto",
            ProfileImageUrl = "images/profile.jpg",
            Contact = new ContactInfo
            {
                Phone = "(11) 99999-9999",
                Email = "victor@test.com",
                Address = "Sao Paulo",
                Website = "victorpersike.dev.br"
            },
            Education = new List<EducationEntry>
            {
                new() { Period = "2022 - 2026", Institution = "Faculdade", Degree = "CC" }
            },
            Experiences = new List<ExperienceEntry>
            {
                new() { Company = "Empresa", Role = "Dev", Period = "2021", Description = "Desc" }
            },
            Skills = new List<SkillEntry>
            {
                new() { Name = "C#", Percentage = 90 },
                new() { Name = "Blazor", Percentage = 85 }
            }
        });
    }
}

/// <summary>
/// Tests organisms with empty/edge-case data.
/// </summary>
public class OrganismEmptyDataTests : BunitContext
{
    public OrganismEmptyDataTests()
    {
        var provider = new EmptyDataProvider();
        var viewModel = new ResumePageViewModel(provider);
        viewModel.LoadAsync().GetAwaiter().GetResult();

        Services.AddSingleton(viewModel);
    }

    [Fact]
    public void HeroSection_WithEmptyData_ShouldRenderEmptyName()
    {
        var cut = Render<HeroSection>();

        var name = cut.Find(".hero-name");
        Assert.Equal(string.Empty, name.TextContent);
    }

    [Fact]
    public void HeroSection_WithEmptyData_ShouldRenderEmptyTitle()
    {
        var cut = Render<HeroSection>();

        var title = cut.Find(".hero-title");
        Assert.Equal(string.Empty, title.TextContent);
    }

    [Fact]
    public void SkillsSection_WithNoSkills_ShouldRenderEmpty()
    {
        var cut = Render<SkillsSection>();

        var items = cut.FindAll(".skill-item");
        Assert.Empty(items);
    }

    [Fact]
    public void ExperienceSection_WithNoExperiences_ShouldRenderEmptyGrid()
    {
        var cut = Render<ExperienceSection>();

        var cards = cut.FindAll(".experience-card");
        Assert.Empty(cards);
    }

    [Fact]
    public void EducationSection_WithNoEducation_ShouldRenderEmptyGrid()
    {
        var cut = Render<EducationSection>();

        var entries = cut.FindAll(".education-entry");
        Assert.Empty(entries);
    }

    private class EmptyDataProvider : IResumeDataProvider
    {
        public Task<ResumeModel> GetResumeAsync() => Task.FromResult(new ResumeModel());
    }
}
