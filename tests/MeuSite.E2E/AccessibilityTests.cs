using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace MeuSite.E2E;

public class AccessibilityTests : PageTest
{
    private const string BaseUrl = "http://localhost:7007";

    [Fact]
    public async Task Page_ShouldHaveTitle()
    {
        await Page.GotoAsync(BaseUrl);
        await Expect(Page).ToHaveTitleAsync(new Regex(".+"));
    }

    [Fact]
    public async Task Page_ShouldHaveMainH1()
    {
        await Page.GotoAsync(BaseUrl);

        var h1 = Page.Locator("h1");
        await Expect(h1).ToBeVisibleAsync();
    }

    [Fact]
    public async Task ProfilePhoto_ShouldHaveAltText()
    {
        await Page.GotoAsync(BaseUrl);

        var img = Page.Locator(".profile-photo img");
        await Expect(img).ToHaveAttributeAsync("alt", new Regex(".+"));
    }

    [Fact]
    public async Task DecorativeDots_ShouldBeAriaHidden()
    {
        await Page.GotoAsync(BaseUrl);

        var dots = Page.Locator(".decorative-dots");
        await Expect(dots).ToHaveAttributeAsync("aria-hidden", "true");
    }

    [Fact]
    public async Task DownloadButton_ShouldHaveHref()
    {
        await Page.GotoAsync(BaseUrl);

        var btn = Page.Locator(".btn-download");
        await Expect(btn).ToHaveAttributeAsync("href", new Regex(".*\\.pdf$"));
    }

    [Fact]
    public async Task ContactSidebar_ShouldHaveContactLabels()
    {
        await Page.GotoAsync(BaseUrl);

        var labels = Page.Locator(".contact-label");
        var count = await labels.CountAsync();
        Assert.True(count >= 1, "Should have at least one contact label");
    }

    [Fact]
    public async Task SkillCircles_ShouldDisplayPercentageText()
    {
        await Page.GotoAsync(BaseUrl);

        var percentages = Page.Locator(".percentage");
        var first = percentages.First;
        await Expect(first).ToBeVisibleAsync();

        var text = await first.TextContentAsync();
        Assert.NotNull(text);
        Assert.Matches(@"\d+%", text);
    }

    [Fact]
    public async Task Page_ShouldNotHaveConsoleErrors()
    {
        var errors = new List<string>();
        Page.Console += (_, msg) =>
        {
            if (msg.Type == "error")
                errors.Add(msg.Text);
        };

        await Page.GotoAsync(BaseUrl);
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // Allow Blazor connection errors that may occur in test environment
        var criticalErrors = errors.Where(e =>
            !e.Contains("WebSocket") &&
            !e.Contains("blazor") &&
            !e.Contains("_framework")).ToList();

        Assert.Empty(criticalErrors);
    }
}
