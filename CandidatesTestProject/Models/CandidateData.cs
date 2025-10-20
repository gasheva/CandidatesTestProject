namespace CandidatesTestProject.Models;

public class CandidateData
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }

    public ICollection<SocialNetwork> SocialNetworks { get; set; } = new List<SocialNetwork>();
    public Candidate? Candidate { get; set; }
    public Employee? Employee { get; set; }
}

