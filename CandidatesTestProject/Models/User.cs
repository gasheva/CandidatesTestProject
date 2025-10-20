namespace CandidatesTestProject.Models;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = "Admin";
    public DateTime CreatedAt { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }

    public ICollection<Candidate> CreatedCandidates { get; set; } = new List<Candidate>();
    public ICollection<Verification> PerformedVerifications { get; set; } = new List<Verification>();
}

