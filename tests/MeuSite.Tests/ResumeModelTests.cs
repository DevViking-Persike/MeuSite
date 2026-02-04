using MeuSite.Shared.Models;

namespace MeuSite.Tests;

public class ResumeModelTests
{
    [Fact]
    public void ResumeModel_DefaultValues_ShouldBeEmpty()
    {
        var model = new ResumeModel();

        Assert.Equal(string.Empty, model.FullName);
        Assert.Equal(string.Empty, model.Title);
        Assert.Equal(string.Empty, model.AboutMe);
        Assert.Empty(model.Education);
        Assert.Empty(model.Experiences);
        Assert.Empty(model.Skills);
    }

    [Fact]
    public void ResumeModel_WithInitValues_ShouldRetainData()
    {
        var model = new ResumeModel
        {
            FullName = "Victor Persike",
            Title = "Desenvolvedor Full-Stack",
            Skills = new List<SkillEntry>
            {
                new() { Name = "C#", Percentage = 80 }
            }
        };

        Assert.Equal("Victor Persike", model.FullName);
        Assert.Single(model.Skills);
        Assert.Equal(80, model.Skills[0].Percentage);
    }

    [Fact]
    public void ContactInfo_DefaultValues_ShouldBeEmpty()
    {
        var contact = new ContactInfo();

        Assert.Equal(string.Empty, contact.Phone);
        Assert.Equal(string.Empty, contact.Email);
        Assert.Equal(string.Empty, contact.Address);
        Assert.Equal(string.Empty, contact.Website);
    }

    [Fact]
    public void SkillEntry_Percentage_ShouldBeInValidRange()
    {
        var skill = new SkillEntry { Name = "C#", Percentage = 80 };

        Assert.True(skill.Percentage >= 0 && skill.Percentage <= 100);
        Assert.False(string.IsNullOrEmpty(skill.Name));
    }

    [Fact]
    public void EducationEntry_ShouldStoreAllFields()
    {
        var entry = new EducationEntry
        {
            Period = "2022 - 2026",
            Institution = "Faculdade Descomplica",
            Degree = "Ciências da Computação EAD"
        };

        Assert.Equal("2022 - 2026", entry.Period);
        Assert.Equal("Faculdade Descomplica", entry.Institution);
        Assert.Equal("Ciências da Computação EAD", entry.Degree);
    }

    [Fact]
    public void ExperienceEntry_ShouldStoreAllFields()
    {
        var entry = new ExperienceEntry
        {
            Company = "Usucampeão",
            Role = "Desenvolvedor Full-Stack",
            Period = "06/21 - 07/22",
            Description = "Descrição do cargo."
        };

        Assert.Equal("Usucampeão", entry.Company);
        Assert.False(string.IsNullOrEmpty(entry.Description));
    }
}
