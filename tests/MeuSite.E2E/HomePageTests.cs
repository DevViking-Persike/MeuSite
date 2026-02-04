using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace MeuSite.E2E;

public class HomePageTests : PageTest
{
    private const string BaseUrl = "http://localhost:7007";

    [Fact]
    public async Task HomePage_ShouldLoad()
    {
        await Page.GotoAsync(BaseUrl);
        await Expect(Page).ToHaveTitleAsync(new Regex(".*"));
        await Expect(Page.Locator("body")).ToBeVisibleAsync();
    }

    [Fact]
    public async Task HomePage_ShouldDisplayHeroSection()
    {
        await Page.GotoAsync(BaseUrl);

        var heroName = Page.Locator(".hero-name");
        await Expect(heroName).ToBeVisibleAsync();
        await Expect(heroName).Not.ToBeEmptyAsync();

        var heroTitle = Page.Locator(".hero-title");
        await Expect(heroTitle).ToBeVisibleAsync();
    }

    [Fact]
    public async Task HomePage_ShouldDisplayProfilePhoto()
    {
        await Page.GotoAsync(BaseUrl);

        var photo = Page.Locator(".profile-photo img");
        await Expect(photo).ToBeVisibleAsync();
        await Expect(photo).ToHaveAttributeAsync("alt", new Regex(".+"));
    }

    [Fact]
    public async Task HomePage_ShouldDisplayAboutSection()
    {
        await Page.GotoAsync(BaseUrl);

        var aboutLabel = Page.Locator(".hero-about-label");
        await Expect(aboutLabel).ToBeVisibleAsync();
        await Expect(aboutLabel).ToHaveTextAsync("Sobre mim");

        var aboutText = Page.Locator(".hero-about");
        await Expect(aboutText).ToBeVisibleAsync();
        await Expect(aboutText).Not.ToBeEmptyAsync();
    }

    [Fact]
    public async Task HomePage_ShouldDisplayContactSidebar()
    {
        await Page.GotoAsync(BaseUrl);

        var sidebar = Page.Locator(".contact-sidebar");
        await Expect(sidebar).ToBeVisibleAsync();

        var sidebarTitle = Page.Locator(".sidebar-title");
        await Expect(sidebarTitle).ToHaveTextAsync("Contato");
    }

    [Fact]
    public async Task HomePage_ShouldDisplaySkillsSection()
    {
        await Page.GotoAsync(BaseUrl);

        var skillsSection = Page.Locator(".skills-section");
        await Expect(skillsSection).ToBeVisibleAsync();

        var skillItems = Page.Locator(".skill-item");
        await Expect(skillItems.First).ToBeVisibleAsync();

        var count = await skillItems.CountAsync();
        Assert.True(count > 0, "Should have at least one skill");
    }

    [Fact]
    public async Task HomePage_ShouldDisplayExperienceSection()
    {
        await Page.GotoAsync(BaseUrl);

        var experienceSection = Page.Locator(".experience-section");
        await Expect(experienceSection).ToBeVisibleAsync();
    }

    [Fact]
    public async Task HomePage_ShouldDisplayEducationSection()
    {
        await Page.GotoAsync(BaseUrl);

        var educationSection = Page.Locator(".education-section");
        await Expect(educationSection).ToBeVisibleAsync();
    }

    [Fact]
    public async Task HomePage_DownloadCvButton_ShouldExist()
    {
        await Page.GotoAsync(BaseUrl);

        var downloadBtn = Page.Locator(".btn-download");
        await Expect(downloadBtn).ToBeVisibleAsync();
        await Expect(downloadBtn).ToContainTextAsync("Baixar CV");
        await Expect(downloadBtn).ToHaveAttributeAsync("href", new Regex(".*curriculo.*\\.pdf"));
    }
}
