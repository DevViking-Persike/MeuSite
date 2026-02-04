using MeuSite.Shared.Models;

namespace MeuSite.Tests;

public class ResumeModelTests
{
    // ==================== ResumeModel ====================

    [Fact]
    public void ResumeModel_DefaultValues_ShouldBeEmpty()
    {
        var model = new ResumeModel();

        Assert.Equal(string.Empty, model.FullName);
        Assert.Equal(string.Empty, model.Title);
        Assert.Equal(string.Empty, model.AboutMe);
        Assert.Equal(string.Empty, model.ProfileImageUrl);
        Assert.Empty(model.Education);
        Assert.Empty(model.Experiences);
        Assert.Empty(model.Skills);
        Assert.NotNull(model.Contact);
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
    public void ResumeModel_WithAllFields_ShouldRetainAllData()
    {
        var contact = new ContactInfo { Phone = "123", Email = "a@b.com", Address = "SP", Website = "site.com" };
        var education = new List<EducationEntry> { new() { Period = "2020", Institution = "Uni", Degree = "CS" } };
        var experiences = new List<ExperienceEntry> { new() { Company = "Corp", Role = "Dev", Period = "2021", Description = "Worked" } };
        var skills = new List<SkillEntry> { new() { Name = "C#", Percentage = 90 } };

        var model = new ResumeModel
        {
            FullName = "Test",
            Title = "Dev",
            AboutMe = "About",
            ProfileImageUrl = "img.jpg",
            Contact = contact,
            Education = education,
            Experiences = experiences,
            Skills = skills
        };

        Assert.Equal("Test", model.FullName);
        Assert.Equal("Dev", model.Title);
        Assert.Equal("About", model.AboutMe);
        Assert.Equal("img.jpg", model.ProfileImageUrl);
        Assert.Same(contact, model.Contact);
        Assert.Single(model.Education);
        Assert.Single(model.Experiences);
        Assert.Single(model.Skills);
    }

    [Fact]
    public void ResumeModel_RecordEquality_SameValues_ShouldBeEqual()
    {
        var skills = new List<SkillEntry>();
        var model1 = new ResumeModel { FullName = "Test", Skills = skills };
        var model2 = new ResumeModel { FullName = "Test", Skills = skills };

        Assert.Equal(model1, model2);
    }

    [Fact]
    public void ResumeModel_RecordEquality_DifferentValues_ShouldNotBeEqual()
    {
        var model1 = new ResumeModel { FullName = "Alice" };
        var model2 = new ResumeModel { FullName = "Bob" };

        Assert.NotEqual(model1, model2);
    }

    [Fact]
    public void ResumeModel_WithInit_ShouldCreateCopyWithChanges()
    {
        var original = new ResumeModel { FullName = "Original", Title = "Dev" };
        var modified = original with { FullName = "Modified" };

        Assert.Equal("Modified", modified.FullName);
        Assert.Equal("Dev", modified.Title);
        Assert.Equal("Original", original.FullName);
    }

    [Fact]
    public void ResumeModel_MultipleSkills_ShouldRetainOrder()
    {
        var skills = new List<SkillEntry>
        {
            new() { Name = "C#", Percentage = 90 },
            new() { Name = "Blazor", Percentage = 85 },
            new() { Name = "SQL", Percentage = 75 }
        };

        var model = new ResumeModel { Skills = skills };

        Assert.Equal(3, model.Skills.Count);
        Assert.Equal("C#", model.Skills[0].Name);
        Assert.Equal("Blazor", model.Skills[1].Name);
        Assert.Equal("SQL", model.Skills[2].Name);
    }

    [Fact]
    public void ResumeModel_MultipleExperiences_ShouldRetainAll()
    {
        var experiences = new List<ExperienceEntry>
        {
            new() { Company = "A", Role = "Dev" },
            new() { Company = "B", Role = "Senior" }
        };

        var model = new ResumeModel { Experiences = experiences };

        Assert.Equal(2, model.Experiences.Count);
    }

    [Fact]
    public void ResumeModel_MultipleEducation_ShouldRetainAll()
    {
        var education = new List<EducationEntry>
        {
            new() { Degree = "BSc" },
            new() { Degree = "MSc" }
        };

        var model = new ResumeModel { Education = education };

        Assert.Equal(2, model.Education.Count);
    }

    // ==================== ContactInfo ====================

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
    public void ContactInfo_WithValues_ShouldRetainData()
    {
        var contact = new ContactInfo
        {
            Phone = "(11) 99999-9999",
            Email = "victor@test.com",
            Address = "Sao Paulo, SP",
            Website = "victorpersike.dev.br"
        };

        Assert.Equal("(11) 99999-9999", contact.Phone);
        Assert.Equal("victor@test.com", contact.Email);
        Assert.Equal("Sao Paulo, SP", contact.Address);
        Assert.Equal("victorpersike.dev.br", contact.Website);
    }

    [Fact]
    public void ContactInfo_RecordEquality_SameValues_ShouldBeEqual()
    {
        var c1 = new ContactInfo { Phone = "123", Email = "a@b.com" };
        var c2 = new ContactInfo { Phone = "123", Email = "a@b.com" };

        Assert.Equal(c1, c2);
    }

    [Fact]
    public void ContactInfo_WithInit_ShouldCreateCopy()
    {
        var original = new ContactInfo { Phone = "123", Email = "a@b.com" };
        var modified = original with { Phone = "456" };

        Assert.Equal("456", modified.Phone);
        Assert.Equal("a@b.com", modified.Email);
        Assert.Equal("123", original.Phone);
    }

    // ==================== SkillEntry ====================

    [Fact]
    public void SkillEntry_Percentage_ShouldBeInValidRange()
    {
        var skill = new SkillEntry { Name = "C#", Percentage = 80 };

        Assert.True(skill.Percentage >= 0 && skill.Percentage <= 100);
        Assert.False(string.IsNullOrEmpty(skill.Name));
    }

    [Fact]
    public void SkillEntry_DefaultValues_ShouldBeEmpty()
    {
        var skill = new SkillEntry();

        Assert.Equal(string.Empty, skill.Name);
        Assert.Equal(0, skill.Percentage);
    }

    [Fact]
    public void SkillEntry_BoundaryPercentage_Zero()
    {
        var skill = new SkillEntry { Name = "New", Percentage = 0 };
        Assert.Equal(0, skill.Percentage);
    }

    [Fact]
    public void SkillEntry_BoundaryPercentage_Hundred()
    {
        var skill = new SkillEntry { Name = "Expert", Percentage = 100 };
        Assert.Equal(100, skill.Percentage);
    }

    [Fact]
    public void SkillEntry_RecordEquality_ShouldWork()
    {
        var s1 = new SkillEntry { Name = "C#", Percentage = 90 };
        var s2 = new SkillEntry { Name = "C#", Percentage = 90 };

        Assert.Equal(s1, s2);
    }

    [Fact]
    public void SkillEntry_DifferentPercentage_ShouldNotBeEqual()
    {
        var s1 = new SkillEntry { Name = "C#", Percentage = 90 };
        var s2 = new SkillEntry { Name = "C#", Percentage = 80 };

        Assert.NotEqual(s1, s2);
    }

    // ==================== EducationEntry ====================

    [Fact]
    public void EducationEntry_ShouldStoreAllFields()
    {
        var entry = new EducationEntry
        {
            Period = "2022 - 2026",
            Institution = "Faculdade Descomplica",
            Degree = "Ciencias da Computacao EAD"
        };

        Assert.Equal("2022 - 2026", entry.Period);
        Assert.Equal("Faculdade Descomplica", entry.Institution);
        Assert.Equal("Ciencias da Computacao EAD", entry.Degree);
    }

    [Fact]
    public void EducationEntry_DefaultValues_ShouldBeEmpty()
    {
        var entry = new EducationEntry();

        Assert.Equal(string.Empty, entry.Period);
        Assert.Equal(string.Empty, entry.Institution);
        Assert.Equal(string.Empty, entry.Degree);
    }

    [Fact]
    public void EducationEntry_RecordEquality_ShouldWork()
    {
        var e1 = new EducationEntry { Period = "2020", Institution = "Uni", Degree = "CS" };
        var e2 = new EducationEntry { Period = "2020", Institution = "Uni", Degree = "CS" };

        Assert.Equal(e1, e2);
    }

    [Fact]
    public void EducationEntry_WithInit_ShouldCreateCopy()
    {
        var original = new EducationEntry { Period = "2020", Institution = "Uni", Degree = "CS" };
        var modified = original with { Degree = "Math" };

        Assert.Equal("Math", modified.Degree);
        Assert.Equal("CS", original.Degree);
    }

    // ==================== ExperienceEntry ====================

    [Fact]
    public void ExperienceEntry_ShouldStoreAllFields()
    {
        var entry = new ExperienceEntry
        {
            Company = "Usucampeao",
            Role = "Desenvolvedor Full-Stack",
            Period = "06/21 - 07/22",
            Description = "Descricao do cargo."
        };

        Assert.Equal("Usucampeao", entry.Company);
        Assert.Equal("Desenvolvedor Full-Stack", entry.Role);
        Assert.Equal("06/21 - 07/22", entry.Period);
        Assert.False(string.IsNullOrEmpty(entry.Description));
    }

    [Fact]
    public void ExperienceEntry_DefaultValues_ShouldBeEmpty()
    {
        var entry = new ExperienceEntry();

        Assert.Equal(string.Empty, entry.Company);
        Assert.Equal(string.Empty, entry.Role);
        Assert.Equal(string.Empty, entry.Period);
        Assert.Equal(string.Empty, entry.Description);
    }

    [Fact]
    public void ExperienceEntry_RecordEquality_ShouldWork()
    {
        var e1 = new ExperienceEntry { Company = "A", Role = "Dev", Period = "2021", Description = "D" };
        var e2 = new ExperienceEntry { Company = "A", Role = "Dev", Period = "2021", Description = "D" };

        Assert.Equal(e1, e2);
    }

    [Fact]
    public void ExperienceEntry_WithInit_ShouldCreateCopy()
    {
        var original = new ExperienceEntry { Company = "A", Role = "Dev" };
        var modified = original with { Company = "B" };

        Assert.Equal("B", modified.Company);
        Assert.Equal("A", original.Company);
        Assert.Equal("Dev", modified.Role);
    }
}
