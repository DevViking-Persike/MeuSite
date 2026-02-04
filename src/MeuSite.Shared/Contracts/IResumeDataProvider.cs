using MeuSite.Shared.Models;

namespace MeuSite.Shared.Contracts;

public interface IResumeDataProvider
{
    Task<ResumeModel> GetResumeAsync();
}
