using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace MeuSite.E2E;

public class ResponsiveTests : PageTest
{
    private const string BaseUrl = "http://localhost:7007";

    [Fact]
    public async Task Mobile_ShouldStackContentVertically()
    {
        await Page.SetViewportSizeAsync(375, 812); // iPhone size
        await Page.GotoAsync(BaseUrl);

        var heroSection = Page.Locator(".hero-section");
        await Expect(heroSection).ToBeVisibleAsync();

        var heroName = Page.Locator(".hero-name");
        await Expect(heroName).ToBeVisibleAsync();
    }

    [Fact]
    public async Task Mobile_ShouldShowAllSections()
    {
        await Page.SetViewportSizeAsync(375, 812);
        await Page.GotoAsync(BaseUrl);

        await Expect(Page.Locator(".hero-section")).ToBeVisibleAsync();
        await Expect(Page.Locator(".contact-sidebar")).ToBeVisibleAsync();
        await Expect(Page.Locator(".skills-section")).ToBeVisibleAsync();
        await Expect(Page.Locator(".experience-section")).ToBeVisibleAsync();
    }

    [Fact]
    public async Task Desktop_ShouldShowFullLayout()
    {
        await Page.SetViewportSizeAsync(1440, 900);
        await Page.GotoAsync(BaseUrl);

        var heroName = Page.Locator(".hero-name");
        await Expect(heroName).ToBeVisibleAsync();

        var skillsSection = Page.Locator(".skills-section");
        await Expect(skillsSection).ToBeVisibleAsync();
    }

    [Fact]
    public async Task Tablet_ShouldAdaptLayout()
    {
        await Page.SetViewportSizeAsync(768, 1024); // iPad size
        await Page.GotoAsync(BaseUrl);

        var heroSection = Page.Locator(".hero-section");
        await Expect(heroSection).ToBeVisibleAsync();

        var skillsSection = Page.Locator(".skills-section");
        await Expect(skillsSection).ToBeVisibleAsync();
    }
}
