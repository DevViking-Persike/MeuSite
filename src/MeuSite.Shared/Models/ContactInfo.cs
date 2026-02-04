namespace MeuSite.Shared.Models;

public record ContactInfo
{
    public string Phone { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Website { get; init; } = string.Empty;
}
