using Bunit;
using MeuSite.Ui.Components.Atoms;

namespace MeuSite.Tests.Components;

public class AtomTests : BunitContext
{
    // ==================== ProfilePhoto ====================

    [Fact]
    public void ProfilePhoto_ShouldRenderWithDefaultValues()
    {
        var cut = Render<ProfilePhoto>();

        var img = cut.Find("img");
        Assert.Equal("images/profile-placeholder.svg", img.GetAttribute("src"));
        Assert.Equal("Profile photo", img.GetAttribute("alt"));
    }

    [Fact]
    public void ProfilePhoto_ShouldRenderWithCustomParameters()
    {
        var cut = Render<ProfilePhoto>(parameters => parameters
            .Add(p => p.Src, "images/profile.jpg")
            .Add(p => p.Alt, "Victor Persike"));

        var img = cut.Find("img");
        Assert.Equal("images/profile.jpg", img.GetAttribute("src"));
        Assert.Equal("Victor Persike", img.GetAttribute("alt"));
    }

    [Fact]
    public void ProfilePhoto_ShouldHaveProfilePhotoContainer()
    {
        var cut = Render<ProfilePhoto>();

        var container = cut.Find(".profile-photo");
        Assert.NotNull(container);
    }

    [Fact]
    public void ProfilePhoto_ShouldRenderSingleImage()
    {
        var cut = Render<ProfilePhoto>();

        var images = cut.FindAll("img");
        Assert.Single(images);
    }

    // ==================== SectionTitle ====================

    [Fact]
    public void SectionTitle_ShouldRenderTitle()
    {
        var cut = Render<SectionTitle>(parameters => parameters
            .Add(p => p.Title, "Experiencia"));

        var h2 = cut.Find("h2");
        Assert.Equal("Experiencia", h2.TextContent);
    }

    [Fact]
    public void SectionTitle_ShouldRenderEmptyByDefault()
    {
        var cut = Render<SectionTitle>();

        var h2 = cut.Find("h2");
        Assert.Equal(string.Empty, h2.TextContent);
    }

    [Fact]
    public void SectionTitle_ShouldHaveSectionTitleContainer()
    {
        var cut = Render<SectionTitle>();

        var container = cut.Find(".section-title");
        Assert.NotNull(container);
    }

    [Fact]
    public void SectionTitle_WithLongText_ShouldRender()
    {
        var longTitle = "Este e um titulo muito longo para testar o comportamento do componente";
        var cut = Render<SectionTitle>(parameters => parameters
            .Add(p => p.Title, longTitle));

        var h2 = cut.Find("h2");
        Assert.Equal(longTitle, h2.TextContent);
    }

    // ==================== SkillCircle ====================

    [Fact]
    public void SkillCircle_ShouldRenderPercentageText()
    {
        var cut = Render<SkillCircle>(parameters => parameters
            .Add(p => p.Percentage, 85));

        var span = cut.Find(".percentage");
        Assert.Equal("85%", span.TextContent);
    }

    [Fact]
    public void SkillCircle_ShouldRenderSvgCircles()
    {
        var cut = Render<SkillCircle>(parameters => parameters
            .Add(p => p.Percentage, 50));

        var circles = cut.FindAll("circle");
        Assert.Equal(2, circles.Count);

        var progressCircle = cut.Find("circle.progress");
        var dashArray = progressCircle.GetAttribute("stroke-dasharray");
        Assert.NotNull(dashArray);
        Assert.NotEmpty(dashArray);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(50)]
    [InlineData(100)]
    public void SkillCircle_ShouldHandleBoundaryPercentages(int percentage)
    {
        var cut = Render<SkillCircle>(parameters => parameters
            .Add(p => p.Percentage, percentage));

        var span = cut.Find(".percentage");
        Assert.Equal($"{percentage}%", span.TextContent);
    }

    [Fact]
    public void SkillCircle_ShouldHaveSkillCircleContainer()
    {
        var cut = Render<SkillCircle>(parameters => parameters
            .Add(p => p.Percentage, 75));

        var container = cut.Find(".skill-circle");
        Assert.NotNull(container);
    }

    [Fact]
    public void SkillCircle_ShouldRenderSvg()
    {
        var cut = Render<SkillCircle>(parameters => parameters
            .Add(p => p.Percentage, 50));

        var svg = cut.Find("svg");
        Assert.NotNull(svg);
        Assert.Equal("0 0 120 120", svg.GetAttribute("viewBox"));
    }

    [Fact]
    public void SkillCircle_BackgroundCircle_ShouldHaveCorrectAttributes()
    {
        var cut = Render<SkillCircle>(parameters => parameters
            .Add(p => p.Percentage, 50));

        var bgCircle = cut.Find("circle.bg");
        Assert.Equal("60", bgCircle.GetAttribute("cx"));
        Assert.Equal("60", bgCircle.GetAttribute("cy"));
        Assert.Equal("54", bgCircle.GetAttribute("r"));
    }

    [Fact]
    public void SkillCircle_ProgressCircle_ShouldHaveStrokeDashoffset()
    {
        var cut = Render<SkillCircle>(parameters => parameters
            .Add(p => p.Percentage, 75));

        var progressCircle = cut.Find("circle.progress");
        var dashOffset = progressCircle.GetAttribute("stroke-dashoffset");
        Assert.NotNull(dashOffset);
        Assert.NotEmpty(dashOffset);
    }

    // ==================== DecorativeDots ====================

    [Fact]
    public void DecorativeDots_ShouldRenderCorrectNumberOfDots()
    {
        var cut = Render<DecorativeDots>(parameters => parameters
            .Add(p => p.Rows, 3)
            .Add(p => p.Columns, 2));

        var rows = cut.FindAll(".dot-row");
        Assert.Equal(3, rows.Count);

        var dots = cut.FindAll(".dot");
        Assert.Equal(6, dots.Count);
    }

    [Fact]
    public void DecorativeDots_ShouldHaveAriaHidden()
    {
        var cut = Render<DecorativeDots>();

        var container = cut.Find(".decorative-dots");
        Assert.Equal("true", container.GetAttribute("aria-hidden"));
    }

    [Fact]
    public void DecorativeDots_ShouldUseDefaultValues()
    {
        var cut = Render<DecorativeDots>();

        var rows = cut.FindAll(".dot-row");
        var dots = cut.FindAll(".dot");
        Assert.Equal(5, rows.Count);
        Assert.Equal(20, dots.Count);
    }

    [Fact]
    public void DecorativeDots_SingleRowSingleColumn_ShouldRenderOneDot()
    {
        var cut = Render<DecorativeDots>(parameters => parameters
            .Add(p => p.Rows, 1)
            .Add(p => p.Columns, 1));

        Assert.Single(cut.FindAll(".dot-row"));
        Assert.Single(cut.FindAll(".dot"));
    }

    [Fact]
    public void DecorativeDots_LargeGrid_ShouldRenderAll()
    {
        var cut = Render<DecorativeDots>(parameters => parameters
            .Add(p => p.Rows, 10)
            .Add(p => p.Columns, 10));

        var dots = cut.FindAll(".dot");
        Assert.Equal(100, dots.Count);
    }

    // ==================== ContactIcon ====================

    [Theory]
    [InlineData("phone")]
    [InlineData("address")]
    [InlineData("email")]
    [InlineData("website")]
    public void ContactIcon_KnownTypes_ShouldRender(string type)
    {
        var cut = Render<ContactIcon>(parameters => parameters
            .Add(p => p.Type, type));

        var span = cut.Find(".contact-icon");
        Assert.NotNull(span);
        Assert.NotEmpty(span.TextContent);
    }

    [Fact]
    public void ContactIcon_ShouldHaveAriaHidden()
    {
        var cut = Render<ContactIcon>(parameters => parameters
            .Add(p => p.Type, "phone"));

        var span = cut.Find(".contact-icon");
        Assert.Equal("true", span.GetAttribute("aria-hidden"));
    }

    [Fact]
    public void ContactIcon_UnknownType_ShouldRenderBullet()
    {
        var cut = Render<ContactIcon>(parameters => parameters
            .Add(p => p.Type, "unknown"));

        var span = cut.Find(".contact-icon");
        Assert.NotNull(span);
        Assert.NotEmpty(span.TextContent);
    }

    [Fact]
    public void ContactIcon_DefaultType_ShouldRender()
    {
        var cut = Render<ContactIcon>();

        var span = cut.Find(".contact-icon");
        Assert.NotNull(span);
    }

    [Fact]
    public void ContactIcon_PhoneType_ShouldRenderPhoneIcon()
    {
        var cut = Render<ContactIcon>(parameters => parameters
            .Add(p => p.Type, "phone"));

        var span = cut.Find(".contact-icon");
        Assert.Equal("\u260E", span.TextContent);
    }

    [Fact]
    public void ContactIcon_EmailType_ShouldRenderEmailIcon()
    {
        var cut = Render<ContactIcon>(parameters => parameters
            .Add(p => p.Type, "email"));

        var span = cut.Find(".contact-icon");
        Assert.Equal("\u2709", span.TextContent);
    }

    [Fact]
    public void ContactIcon_AddressType_ShouldRenderHouseIcon()
    {
        var cut = Render<ContactIcon>(parameters => parameters
            .Add(p => p.Type, "address"));

        var span = cut.Find(".contact-icon");
        Assert.Equal("\u2302", span.TextContent);
    }
}
