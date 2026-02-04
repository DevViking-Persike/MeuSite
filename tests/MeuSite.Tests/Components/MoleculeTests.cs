using Bunit;
using MeuSite.Ui.Components.Molecules;

namespace MeuSite.Tests.Components;

public class MoleculeTests : BunitContext
{
    // ==================== ContactItem ====================

    [Fact]
    public void ContactItem_ShouldRenderLabelAndValue()
    {
        var cut = Render<ContactItem>(parameters => parameters
            .Add(p => p.Label, "Celular")
            .Add(p => p.Value, "(11) 99999-9999"));

        var label = cut.Find(".contact-label");
        Assert.Equal("Celular", label.TextContent);

        var value = cut.Find(".contact-value");
        Assert.Equal("(11) 99999-9999", value.TextContent);
    }

    [Fact]
    public void ContactItem_ShouldHaveContactItemContainer()
    {
        var cut = Render<ContactItem>(parameters => parameters
            .Add(p => p.Label, "Email")
            .Add(p => p.Value, "test@test.com"));

        var container = cut.Find(".contact-item");
        Assert.NotNull(container);
    }

    [Fact]
    public void ContactItem_DefaultValues_ShouldRenderEmpty()
    {
        var cut = Render<ContactItem>();

        var label = cut.Find(".contact-label");
        Assert.Equal(string.Empty, label.TextContent);

        var value = cut.Find(".contact-value");
        Assert.Equal(string.Empty, value.TextContent);
    }

    [Fact]
    public void ContactItem_LabelRendersAsH4()
    {
        var cut = Render<ContactItem>(parameters => parameters
            .Add(p => p.Label, "Website"));

        var h4 = cut.Find("h4");
        Assert.Equal("Website", h4.TextContent);
    }

    [Fact]
    public void ContactItem_ValueRendersAsParagraph()
    {
        var cut = Render<ContactItem>(parameters => parameters
            .Add(p => p.Value, "example.com"));

        var p = cut.Find("p");
        Assert.Equal("example.com", p.TextContent);
    }

    // ==================== EducationEntryItem ====================

    [Fact]
    public void EducationEntryItem_ShouldRenderAllFields()
    {
        var cut = Render<EducationEntryItem>(parameters => parameters
            .Add(p => p.Period, "2022 - 2026")
            .Add(p => p.Institution, "Faculdade Descomplica")
            .Add(p => p.Degree, "Ciencias da Computacao"));

        var period = cut.Find(".period");
        Assert.Equal("2022 - 2026", period.TextContent);

        var institution = cut.Find(".institution");
        Assert.Equal("Faculdade Descomplica", institution.TextContent);

        var degree = cut.Find(".degree");
        Assert.Equal("Ciencias da Computacao", degree.TextContent);
    }

    [Fact]
    public void EducationEntryItem_ShouldHaveContainer()
    {
        var cut = Render<EducationEntryItem>();

        var container = cut.Find(".education-entry");
        Assert.NotNull(container);
    }

    [Fact]
    public void EducationEntryItem_DefaultValues_ShouldRenderEmpty()
    {
        var cut = Render<EducationEntryItem>();

        var period = cut.Find(".period");
        Assert.Equal(string.Empty, period.TextContent);

        var institution = cut.Find(".institution");
        Assert.Equal(string.Empty, institution.TextContent);

        var degree = cut.Find(".degree");
        Assert.Equal(string.Empty, degree.TextContent);
    }

    [Fact]
    public void EducationEntryItem_InstitutionRendersAsH4()
    {
        var cut = Render<EducationEntryItem>(parameters => parameters
            .Add(p => p.Institution, "UNICAMP"));

        var h4 = cut.Find("h4.institution");
        Assert.Equal("UNICAMP", h4.TextContent);
    }

    [Fact]
    public void EducationEntryItem_DegreeRenderedInList()
    {
        var cut = Render<EducationEntryItem>(parameters => parameters
            .Add(p => p.Degree, "Bacharelado em CC"));

        var li = cut.Find("li.degree");
        Assert.Equal("Bacharelado em CC", li.TextContent);
    }

    [Fact]
    public void EducationEntryItem_ShouldContainUl()
    {
        var cut = Render<EducationEntryItem>();

        var ul = cut.Find("ul");
        Assert.NotNull(ul);
    }

    // ==================== ExperienceCard ====================

    [Fact]
    public void ExperienceCard_ShouldRenderAllFields()
    {
        var cut = Render<ExperienceCard>(parameters => parameters
            .Add(p => p.Company, "Usucampeao")
            .Add(p => p.Role, "Desenvolvedor")
            .Add(p => p.Period, "06/21 - 07/22")
            .Add(p => p.Description, "Desenvolvimento de sistemas."));

        var company = cut.Find(".company");
        Assert.Equal("Usucampeao", company.TextContent);

        var rolePeriod = cut.Find(".role-period");
        Assert.Contains("Desenvolvedor", rolePeriod.TextContent);
        Assert.Contains("06/21 - 07/22", rolePeriod.TextContent);

        var desc = cut.Find(".description");
        Assert.Equal("Desenvolvimento de sistemas.", desc.TextContent);
    }

    [Fact]
    public void ExperienceCard_ShouldHaveContainer()
    {
        var cut = Render<ExperienceCard>();

        var container = cut.Find(".experience-card");
        Assert.NotNull(container);
    }

    [Fact]
    public void ExperienceCard_DefaultValues_ShouldRenderEmpty()
    {
        var cut = Render<ExperienceCard>();

        var company = cut.Find(".company");
        Assert.Equal(string.Empty, company.TextContent);

        var desc = cut.Find(".description");
        Assert.Equal(string.Empty, desc.TextContent);
    }

    [Fact]
    public void ExperienceCard_CompanyRendersAsH4()
    {
        var cut = Render<ExperienceCard>(parameters => parameters
            .Add(p => p.Company, "Google"));

        var h4 = cut.Find("h4.company");
        Assert.Equal("Google", h4.TextContent);
    }

    [Fact]
    public void ExperienceCard_RoleAndPeriodCombined()
    {
        var cut = Render<ExperienceCard>(parameters => parameters
            .Add(p => p.Role, "Dev")
            .Add(p => p.Period, "2023"));

        var rolePeriod = cut.Find(".role-period");
        Assert.Contains("Dev", rolePeriod.TextContent);
        Assert.Contains("2023", rolePeriod.TextContent);
    }

    // ==================== SkillItem ====================

    [Fact]
    public void SkillItem_ShouldRenderNameAndCircle()
    {
        var cut = Render<SkillItem>(parameters => parameters
            .Add(p => p.Name, "C#")
            .Add(p => p.Percentage, 90));

        var name = cut.Find(".skill-name");
        Assert.Equal("C#", name.TextContent);

        var percentage = cut.Find(".percentage");
        Assert.Equal("90%", percentage.TextContent);
    }

    [Fact]
    public void SkillItem_ShouldHaveContainer()
    {
        var cut = Render<SkillItem>(parameters => parameters
            .Add(p => p.Name, "Test")
            .Add(p => p.Percentage, 50));

        var container = cut.Find(".skill-item");
        Assert.NotNull(container);
    }

    [Fact]
    public void SkillItem_DefaultName_ShouldBeEmpty()
    {
        var cut = Render<SkillItem>();

        var name = cut.Find(".skill-name");
        Assert.Equal(string.Empty, name.TextContent);
    }

    [Fact]
    public void SkillItem_ShouldContainSkillCircle()
    {
        var cut = Render<SkillItem>(parameters => parameters
            .Add(p => p.Name, "Blazor")
            .Add(p => p.Percentage, 85));

        var circle = cut.Find(".skill-circle");
        Assert.NotNull(circle);
    }

    [Fact]
    public void SkillItem_ZeroPercentage_ShouldRender()
    {
        var cut = Render<SkillItem>(parameters => parameters
            .Add(p => p.Name, "New Skill")
            .Add(p => p.Percentage, 0));

        var percentage = cut.Find(".percentage");
        Assert.Equal("0%", percentage.TextContent);
    }

    [Fact]
    public void SkillItem_HundredPercentage_ShouldRender()
    {
        var cut = Render<SkillItem>(parameters => parameters
            .Add(p => p.Name, "Expert")
            .Add(p => p.Percentage, 100));

        var percentage = cut.Find(".percentage");
        Assert.Equal("100%", percentage.TextContent);
    }
}
